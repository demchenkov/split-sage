using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace SplitSage.Bot.Telegram.Common.Infrastructure.Bot;

public static class DependencyInjection
{
    public static IServiceCollection AddTelegramBot(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<TelegramOptions>(configuration.GetSection("Telegram"));
        
        services.AddHttpClient<ITelegramBotClient, TelegramBotClient>((client, sp) =>
        {
            var botConfiguration = sp.GetRequiredService<IOptions<TelegramOptions>>().Value;
            ArgumentNullException.ThrowIfNull(botConfiguration.Token);
    
            var options = new TelegramBotClientOptions(botConfiguration.Token);
            return new TelegramBotClient(options, client);
        });
        services.AddHostedService<TelegramPollingService>();
        services.AddScoped<IUpdateHandler, TelegramBotUpdateHandler>();
        
        return services;
    }
}