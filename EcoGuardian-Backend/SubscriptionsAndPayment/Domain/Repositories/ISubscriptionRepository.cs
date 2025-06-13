using EcoGuardian_Backend.Shared.Domain.Repositories;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Aggregates;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Repositories;

public interface ISubscriptionRepository : IBaseRepository<Subscription>
{
    Task<Subscription?> FindByUserIdAsync(int userId);
    Task<IEnumerable<Subscription>> ListAllAsync();
    Task<Subscription?> FindByIdAsync(int id);
}