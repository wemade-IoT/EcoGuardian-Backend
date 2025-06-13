using EcoGuardian_Backend.Shared.Domain.Repositories;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Entities;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.ValueObjects;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Repositories;

public interface ISubscriptionStateRepository : IBaseRepository<SubscriptionState>
{
    Task<bool> isSubcriptionStateExistsAsync(string? subscriptionState);
}