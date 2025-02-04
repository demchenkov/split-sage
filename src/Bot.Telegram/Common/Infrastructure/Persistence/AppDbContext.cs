using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SplitSage.Bot.Telegram.Common.Application;
using SplitSage.Bot.Telegram.Features.Expenses;
using SplitSage.Bot.Telegram.Features.Groups;
using SplitSage.Bot.Telegram.Features.Settlements;
using SplitSage.Bot.Telegram.Features.Users;

namespace SplitSage.Bot.Telegram.Common.Infrastructure.Persistence;

public class AppDbContext(
    DbContextOptions<AppDbContext> options
    ) : DbContext(options), IAppDbContext
{
    public DbSet<User> Users => Set<User>();
    
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<GroupMembership> GroupMemberships => Set<GroupMembership>();
    
    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<ExpenseShare> ExpenseShares => Set<ExpenseShare>();
    
    public DbSet<Settlement> Settlements => Set<Settlement>();
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}