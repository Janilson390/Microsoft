using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("User")
            .HasKey(u => u.Id);

        builder
            .HasMany(u => u.Skills)
            .WithOne()
            .HasForeignKey(u => u.IdSkill)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
