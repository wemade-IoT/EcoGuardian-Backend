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
        modelBuilder.ApplyConfiguration(new QuestionConfigurationBuilder());
        modelBuilder.ApplyConfiguration(new AnswerConfigurationBuilder());
       modelBuilder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.AddInterceptors();
    }
}