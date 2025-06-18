namespace EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Commands;

public record UpdateSubscriptionTypeCommand(
    int Id,
    int UserId,
    int SubscriptionTypeId
);