using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence;

public class DevFreelaDbContext : DbContext
{
    public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<UserSkill> UserSkills { get; private set; }
    public DbSet<ProjectComments> ProjectComments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>()
        .ToTable("Project")
        .HasKey(p => p.Id);

        modelBuilder.Entity<Project>()
        .HasOne(p => p.Client)
        .WithMany( o => o.OwnedProjects)
        .HasForeignKey(p => p.IdClient)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectComments>()
        .ToTable("ProjectComments")
        .HasKey(p => p.Id);

        modelBuilder.Entity<ProjectComments>()
        .HasOne(p => p.Project)
        .WithMany(p => p.Comments)
        .HasForeignKey(p => p.IdProject);

        modelBuilder.Entity<ProjectComments>()
        .HasOne(p => p.User)
        .WithMany(p => p.Comments)
        .HasForeignKey(p => p.IdUser);

        modelBuilder.Entity<Skill>()
        .ToTable("Skill")
        .HasKey(s => s.Id);

        modelBuilder.Entity<User>()
       .ToTable("User")
       .HasKey(u => u.Id);

       modelBuilder.Entity<User>()
       .HasMany(u => u.Skills)
       .WithOne()
       .HasForeignKey (u => u.IdSkill)
       .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UserSkill>()
        .ToTable("UserSkill")
        .HasKey(u => u.Id);

    }

}
