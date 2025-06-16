using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Builders;


public class IoTDataConfigurationBuilder : IEntityTypeConfiguration<IoTData>
{
    public void Configure(EntityTypeBuilder<IoTData> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.DeviceId)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.DataType)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(x => x.Value)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.Unit)
            .IsRequired()
            .HasMaxLength(20);
        
        builder.Property(x => x.Timestamp)
            .IsRequired();
        
        builder.Property(x => x.CreatedAt);
        builder.Property(x => x.UpdatedAt);
        
        // Crear índices para búsquedas comunes
        builder.HasIndex(x => x.DeviceId);
        builder.HasIndex(x => new { x.DeviceId, x.DataType });
        builder.HasIndex(x => new { x.DeviceId, x.Timestamp });
    }
}
