using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Builders;

public class WellnessStateConfigurationBuilder : IEntityTypeConfiguration<WellnessState>
{
    public void Configure(EntityTypeBuilder<WellnessState> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        builder.Property(x => x.Type)
            .IsRequired();
            
    }
}