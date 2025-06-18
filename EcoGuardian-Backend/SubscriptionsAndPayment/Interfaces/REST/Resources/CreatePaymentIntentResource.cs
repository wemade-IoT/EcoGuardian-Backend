namespace EcoGuardian_Backend.SubscriptionsAndPayment.Interfaces.REST.Resources;

public record CreatePaymentIntentResource(decimal Amount, string Currency, string PaymentMethodId);