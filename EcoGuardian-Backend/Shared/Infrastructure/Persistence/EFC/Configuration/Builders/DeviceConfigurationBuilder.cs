using EcoGuardian_Backend.Resources.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Builders;

public class DeviceConfigurationBuilder : IEntityTypeConfiguration<Device>
{
    public void Configure(EntityTypeBuilder<Device> builder)
    {
        builder.ToTable("devices");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).ValueGeneratedOnAdd();
        builder.Property(d => d.DeviceId).IsRequired().HasMaxLength(100);
        builder.Property(d => d.ApiKey).IsRequired().HasMaxLength(100);
        builder.HasIndex(d => d.DeviceId).IsUnique();
    }
}

