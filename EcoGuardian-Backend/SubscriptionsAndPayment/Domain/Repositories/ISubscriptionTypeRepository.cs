using EcoGuardian_Backend.Shared.Domain.Repositories;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Entities;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.ValueObjects;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Repositories;

public interface ISubscriptionTypeRepository : IBaseRepository<SubscriptionType>
{
    Task<bool> isSubcriptionTypeExistsAsync(string? subscriptionType);
}