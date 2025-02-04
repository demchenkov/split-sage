using SplitSage.Bot.Telegram.Features.Groups;
using SplitSage.Bot.Telegram.Features.Users;

namespace SplitSage.Bot.Telegram.Features.Settlements;

public class Settlement
{
    public Guid Id { get; init; }
    
    public Guid FromUserId { get; init; }  // The user making the payment
    public User FromUser { get; init; } = null!;

    public Guid ToUserId { get; init; }  // The user receiving the payment
    public User ToUser { get; init; } = null!;

    public Guid GroupId { get; init; }
    public Group Group { get; init; } = null!;

    public decimal Amount { get; init; }
    public DateTime Date { get; init; } = DateTime.UtcNow;
}