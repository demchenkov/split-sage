using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace SplitSage.Bot.Telegram.Common.Infrastructure.Bot;

public class TelegramPollingService(
    ILogger<TelegramPollingService> logger, 
    IServiceScopeFactory scopeFactory
    ) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Starting polling service");
        
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await using var scope = scopeFactory.CreateAsyncScope();

                var client = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();
                var options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<TelegramOptions>>().Value;
                
                var receiverOptions = new ReceiverOptions
                {
                    DropPendingUpdates = options.DropPendingUpdates, 
                    AllowedUpdates = []
                };

                var handler = scope.ServiceProvider.GetRequiredService<IUpdateHandler>();
                await client.ReceiveAsync(handler, receiverOptions, stoppingToken);
                
            }
            catch (Exception ex)
            {
                logger.LogError("Polling failed with exception: {Exception}", ex);
                // Cooldown if something goes wrong
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }
    }
}