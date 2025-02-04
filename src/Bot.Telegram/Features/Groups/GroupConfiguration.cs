using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.EntityFrameworkCore.PostgreSQL.ValueGeneration;

namespace SplitSage.Bot.Telegram.Features.Groups;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(g => g.Id);

        builder.Property(g => g.Id)
            .HasValueGenerator<NpgsqlSequentialGuidValueGenerator>();
        
        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(g => g.Members)
            .WithOne(m => m.Group)
            .HasForeignKey(m => m.GroupId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(g => g.Settlements)
            .WithOne(s => s.Group)
            .HasForeignKey(s => s.GroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class GroupMembershipConfiguration : IEntityTypeConfiguration<GroupMembership>
{
    public void Configure(EntityTypeBuilder<GroupMembership> builder)
    {
        builder.HasKey(ug => new { ug.UserId, ug.GroupId });

        builder.HasOne(ug => ug.User)
            .WithMany(u => u.Groups)
            .HasForeignKey(ug => ug.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ug => ug.Group)
            .WithMany(g => g.Members)
            .HasForeignKey(ug => ug.GroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}