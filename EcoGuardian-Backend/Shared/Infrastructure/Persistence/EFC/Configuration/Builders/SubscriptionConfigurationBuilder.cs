using EcoGuardian_Backend.IAM.Domain.Model.Aggregates;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Aggregates;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Builders;

public class SubscriptionConfigurationBuilder: IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        builder.Property(x => x.UserId)
            .IsRequired();
        builder.Property(x => x.SubscriptionTypeId)
            .IsRequired();
        builder.Property(x => x.SubscriptionStateId)
            .IsRequired();
        builder.Property(x => x.Amount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        builder.Property(x => x.Currency)
            .IsRequired();
        builder.Property(x => x.CreatedAt);
        builder.Property(x => x.UpdatedAt);
        builder.Property(x => x.ExpirationDate)
            .IsRequired();
        builder.HasOne<SubscriptionState>().WithMany().HasForeignKey(x => x.SubscriptionStateId);
        builder.HasOne<SubscriptionType>().WithMany().HasForeignKey(x => x.SubscriptionTypeId);
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UserId);
    }
}