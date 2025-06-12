namespace EcoGuardian_Backend.SubscriptionsAndPayment.Interfaces.REST.Resources;

public record CreateSubscriptionResource(
    int UserId,
    int SubscriptionTypeId,
    int SubscriptionStateId,
    string Currency,
    decimal Amount
);