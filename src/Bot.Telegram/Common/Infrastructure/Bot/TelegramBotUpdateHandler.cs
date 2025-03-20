using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace SplitSage.Bot.Telegram.Common.Infrastructure.Bot;

public class TelegramBotUpdateHandler : IUpdateHandler
{
    public Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, HandleErrorSource source,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}