namespace SplitSage.Bot.Telegram.Common.Infrastructure.Bot;

public class TelegramOptions
{
    public required string Token { get; init; }
    public bool DropPendingUpdates { get; set; } = true;
}