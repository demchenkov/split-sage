using SplitSage.Bot.Telegram.Features.Groups;

namespace SplitSage.Bot.Telegram.Features.Users;

public class User
{
    public Guid Id { get; init; }  // Primary Key
    public long? TelegramId { get; init; } // Unique Telegram user identifier
    
    public ICollection<GroupMembership> Groups { get; init; } = new List<GroupMembership>();
}