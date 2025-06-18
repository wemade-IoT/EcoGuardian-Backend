using EcoGuardian_Backend.Planning.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Builders;

public class OrderStateConfigurationBuilder : IEntityTypeConfiguration<OrderState>
{
    public void Configure(EntityTypeBuilder<OrderState> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        builder.Property(x => x.Type)
            .IsRequired();
        
    }
}