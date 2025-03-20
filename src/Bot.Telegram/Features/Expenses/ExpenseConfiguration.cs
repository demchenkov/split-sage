using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.EntityFrameworkCore.PostgreSQL.ValueGeneration;

namespace SplitSage.Bot.Telegram.Features.Expenses;

public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.HasKey(ex => ex.Id);

        builder.Property(g => g.Id)
            .HasValueGenerator<NpgsqlSequentialGuidValueGenerator>();

        builder.Property(g => g.Description)
            .IsRequired()
            .HasMaxLength(2000);

        builder.Property(g => g.Date).IsRequired();

        builder.Property(g => g.PaidByUserId).IsRequired();
        builder.Property(g => g.GroupId).IsRequired();

        builder.Property(ex => ex.Amount)
            .IsRequired()
            .HasPrecision(18, 2); // Ensuring correct decimal precision for money

        builder.HasOne(ex => ex.PaidBy)
            .WithMany()
            .HasForeignKey(ex => ex.PaidByUserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ex => ex.Group)
            .WithMany(g => g.Expenses)
            .HasForeignKey(ex => ex.GroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}