using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Commands;
using EcoGuardian_Backend.SubscriptionsAndPayment.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Interfaces.REST.Transform;

public class CreatePaymentIntentCommandFromResourceAssembler
{
    public static CreatePaymentIntentCommand ToCommandFromResource(CreatePaymentIntentResource resource)
    {
        return new CreatePaymentIntentCommand(
            resource.Amount,
            resource.Currency,
            resource.PaymentMethodId
        );
    }
}