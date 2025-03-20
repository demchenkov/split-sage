using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.EntityFrameworkCore.PostgreSQL.ValueGeneration;

namespace SplitSage.Bot.Telegram.Features.Expenses;

public class ExpenseShareConfiguration : IEntityTypeConfiguration<ExpenseShare>
{
    public void Configure(EntityTypeBuilder<ExpenseShare> builder)
    {
        builder.HasKey(es => es.Id);

        builder.Property(g => g.Id)
            .HasValueGenerator<NpgsqlSequentialGuidValueGenerator>();

        builder.Property(s => s.Amount)
            .IsRequired()
            .HasPrecision(18, 2); // Ensuring correct decimal precision for money

        builder.HasOne(es => es.User)
            .WithMany()
            .HasForeignKey(es => es.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(es => es.Expense)
            .WithMany(g => g.Shares)
            .HasForeignKey(es => es.ExpenseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}