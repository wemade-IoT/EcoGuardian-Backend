using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Builders;

public class PaymentConfigurationBuilder : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        builder.Property(x => x.UserId)
            .IsRequired();
        builder.Property(x => x.Amount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        builder.Property(x => x.Currency)
            .IsRequired();
        builder.Property(x => x.PaymentMethodId)
            .IsRequired();
        builder.Property(x => x.PaymentIntentId)
            .IsRequired();
        builder.Property(x => x.PaymentStatus)
            .IsRequired();
        builder.Property(x => x.ReferenceId)
            .IsRequired();
        builder.Property(x => x.ReferenceType)
            .IsRequired();
        builder.Property(x => x.CreatedAt);
        builder.Property(x => x.UpdatedAt);
    }
}