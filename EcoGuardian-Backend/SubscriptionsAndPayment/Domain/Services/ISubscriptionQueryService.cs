using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Aggregates;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Queries;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Services;

public interface ISubscriptionQueryService
{
    Task<Subscription?> Handle(GetSubscriptionById query);
    Task<Subscription?> Handle(GetSubscriptionByUserIdQuery query);
    Task<IEnumerable<Subscription>> Handle(GetAllSubscriptions query);
}