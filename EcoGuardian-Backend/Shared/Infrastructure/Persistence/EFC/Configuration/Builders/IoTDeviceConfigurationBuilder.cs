using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Builders;

public class IoTDeviceConfigurationBuilder : IEntityTypeConfiguration<IoTDevice>
{
    public void Configure(EntityTypeBuilder<IoTDevice> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.DeviceId)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.Type)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(x => x.Manufacturer)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.Model)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.FirmwareVersion)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(x => x.IsActive)
            .IsRequired();
        
        builder.Property(x => x.Location)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(x => x.PlantId);
        
        builder.Property(x => x.UserId)
            .IsRequired();
        
        builder.Property(x => x.CreatedAt);
        builder.Property(x => x.UpdatedAt);
        
        builder.HasIndex(x => x.DeviceId).IsUnique();
    }
}
