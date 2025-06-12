using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.ValueObjects;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Commands;

public record CreatePaymentCommand(
    string PaymentIntentId,
    string PaymentMethodId,
    decimal Amount,
    string Currency,
    string PaymentStatus,
    int UserId,
    int ReferenceId,
    EPaymentReferenceType ReferenceType
);