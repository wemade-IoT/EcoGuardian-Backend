namespace EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Commands;

public record CreatePaymentIntentCommand(decimal Amount, string Currency, string PaymentMethodId);