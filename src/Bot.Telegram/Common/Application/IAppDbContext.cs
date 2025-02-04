using Microsoft.EntityFrameworkCore;
using SplitSage.Bot.Telegram.Features.Expenses;
using SplitSage.Bot.Telegram.Features.Groups;
using SplitSage.Bot.Telegram.Features.Settlements;
using SplitSage.Bot.Telegram.Features.Users;

namespace SplitSage.Bot.Telegram.Common.Application;

public interface IAppDbContext
{
    DbSet<User> Users { get; }
    
    DbSet<Group> Groups { get; }
    DbSet<GroupMembership> GroupMemberships { get; }
    
    DbSet<Expense> Expenses { get; }
    DbSet<ExpenseShare> ExpenseShares { get; }
    
    DbSet<Settlement> Settlements { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}