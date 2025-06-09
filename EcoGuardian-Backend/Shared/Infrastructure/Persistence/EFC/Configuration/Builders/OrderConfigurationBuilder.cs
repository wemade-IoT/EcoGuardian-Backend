using EcoGuardian_Backend.Planning.Domain.Model.Aggregates;
using EcoGuardian_Backend.Planning.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Builders;

public class OrderConfigurationBuilder : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        builder.Property(x => x.Action)
            .IsRequired();
        builder.Property(x => x.CreatedAt);
        builder.Property(x => x.CompletedAt);
        builder.Property(x => x.ConsumerId)
            .IsRequired();
        builder.Property(x => x.SpecialistId);
        builder.Property(x => x.InstallationDate);
        builder.HasOne<OrderState>().WithMany().HasForeignKey(x => x.StateId);
        builder.HasMany(o => o.OrderDetails)
            .WithOne()
            .HasForeignKey(od => od.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}