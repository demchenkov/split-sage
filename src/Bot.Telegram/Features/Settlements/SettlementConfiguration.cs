using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.EntityFrameworkCore.PostgreSQL.ValueGeneration;

namespace SplitSage.Bot.Telegram.Features.Settlements;

public class SettlementConfiguration : IEntityTypeConfiguration<Settlement>
{
    public void Configure(EntityTypeBuilder<Settlement> builder)
    {
        builder.HasKey(s => s.Id);
        
        builder.Property(s => s.Id)
            .HasValueGenerator<NpgsqlSequentialGuidValueGenerator>();
        
        builder.Property(s => s.FromUserId).IsRequired();
        builder.Property(s => s.ToUserId).IsRequired();
        
        builder.Property(g => g.Date).IsRequired();
        
        builder.Property(ex => ex.Amount)
            .IsRequired()
            .HasPrecision(18, 2); // Ensuring correct decimal precision for money

        builder.HasOne(s => s.FromUser)
            .WithMany()
            .HasForeignKey(s => s.FromUserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(s => s.ToUser)
            .WithMany()
            .HasForeignKey(s => s.ToUserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(s => s.Group)
            .WithMany(g => g.Settlements)
            .HasForeignKey(m => m.GroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}