using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Commands;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Services;

public interface ISubscriptionTypeCommandService
{
    Task Handle(SeedSubscriptionTypesCommand command);
}