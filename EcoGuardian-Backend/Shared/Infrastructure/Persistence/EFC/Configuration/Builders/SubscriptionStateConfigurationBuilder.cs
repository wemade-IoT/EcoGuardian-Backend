using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Builders;

public class SubscriptionStateConfigurationBuilder : IEntityTypeConfiguration<SubscriptionState>
{
    public void Configure(EntityTypeBuilder<SubscriptionState> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        builder.Property(x => x.State)
            .IsRequired();
    }
}