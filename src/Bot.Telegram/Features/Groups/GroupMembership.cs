using SplitSage.Bot.Telegram.Features.Users;

namespace SplitSage.Bot.Telegram.Features.Groups;

public class GroupMembership
{
    public Guid UserId { get; init; }
    public User User { get; init; } = null!;

    public Guid GroupId { get; init; }
    public Group Group { get; init; } = null!;
}