using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations;

public class ProjectCommentsConfigurations : IEntityTypeConfiguration<ProjectComments>
{
    public void Configure(EntityTypeBuilder<ProjectComments> builder)
    {
        builder
            .ToTable("ProjectComments")
            .HasKey(p => p.Id);

        builder
            .HasOne(p => p.Project)
            .WithMany(p => p.Comments)
            .HasForeignKey(p => p.IdProject);

        builder
            .HasOne(p => p.User)
            .WithMany(p => p.Comments)
            .HasForeignKey(p => p.IdUser);
    }
}
