using EcoGuardian_Backend.IAM.Domain.Model.Aggregates;
using EcoGuardian_Backend.IAM.Domain.Model.Entities;
using EcoGuardian_Backend.IAM.Domain.Model.ValueObjects;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Builders;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new WellnessStateConfigurationBuilder());
        modelBuilder.ApplyConfiguration(new PlantConfigurationBuilder());
        
        //IAM Context
        
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<User>().Property(u => u.Username).IsRequired();
        modelBuilder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();
        modelBuilder.Entity<UserRole>().HasMany<User>().WithOne().HasForeignKey(u => u.RoleId);

        modelBuilder.Entity<UserRole>().HasKey(ur => ur.Id);
        modelBuilder.Entity<UserRole>().Property(ur => ur.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<UserRole>().Property(ur => ur.Role).IsRequired();
        
        
        modelBuilder.UseSnakeCaseWithPluralizedTableNamingConvention();
        
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.AddInterceptors();
    }
}