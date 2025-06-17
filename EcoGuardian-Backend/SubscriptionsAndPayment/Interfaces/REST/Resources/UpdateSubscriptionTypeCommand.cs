using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Entities;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Interfaces.REST.Resources;

public record UpdateSubscriptionTypeCommand(
    int Id,
    int UserId,
    int SubscriptionTypeId
);