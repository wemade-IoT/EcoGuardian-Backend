using EcoGuardian_Backend.Analytics.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Builders;

public class MetricTypeConfigurationBuilder : IEntityTypeConfiguration<MetricType>
{
    public void Configure(EntityTypeBuilder<MetricType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Type).IsRequired();
    }
}

