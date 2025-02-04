using SplitSage.Bot.Telegram.Features.Groups;
using SplitSage.Bot.Telegram.Features.Users;

namespace SplitSage.Bot.Telegram.Features.Expenses;

public class Expense
{
    public Guid Id { get; init; }
    
    public Guid GroupId { get; init; }
    public Group Group { get; init; } = null!;

    public Guid PaidByUserId { get; init; }
    public User PaidBy { get; init; } = null!; // User who paid for the expense
    
    public decimal Amount { get; init; }
    public string Description { get; init; } = string.Empty;
    public DateTime Date { get; init; } = DateTime.UtcNow;

    public ICollection<ExpenseShare> Shares { get; init; } = new List<ExpenseShare>();
}