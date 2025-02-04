using SplitSage.Bot.Telegram.Features.Expenses;
using SplitSage.Bot.Telegram.Features.Settlements;

namespace SplitSage.Bot.Telegram.Features.Groups;

public class Group
{
    public Guid Id { get; init; }  // Primary Key
    public string Name { get; init; } = string.Empty;
    
    public ICollection<GroupMembership> Members { get; init; } = new List<GroupMembership>();
    public ICollection<Expense> Expenses { get; init; } = new List<Expense>();
    public ICollection<Settlement> Settlements { get; init; } = new List<Settlement>();
}