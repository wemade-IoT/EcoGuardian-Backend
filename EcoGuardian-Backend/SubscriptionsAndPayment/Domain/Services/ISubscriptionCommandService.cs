using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Aggregates;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Commands;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Services;

public interface ISubscriptionCommandService
{
    public Task<Subscription?> Handle(CreateSubscriptionCommand command);
    public Task<Subscription?> Handle(UpdateSubscriptionTypeCommand command);
}