using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.EntityFrameworkCore.PostgreSQL.ValueGeneration;

namespace SplitSage.Bot.Telegram.Features.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(g => g.Id);
        
        builder.Property(g => g.Id)
            .HasValueGenerator<NpgsqlSequentialGuidValueGenerator>();
        
        builder.HasMany(x => x.Groups)
            .WithOne(g => g.User)
            .HasForeignKey(g => g.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}