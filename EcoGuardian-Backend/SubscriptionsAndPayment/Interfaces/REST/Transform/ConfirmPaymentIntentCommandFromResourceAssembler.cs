using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Commands;
using EcoGuardian_Backend.SubscriptionsAndPayment.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Interfaces.REST.Transform;

public class ConfirmPaymentIntentCommandFromResourceAssembler
{
    public static ConfirmPaymentIntentCommand ToCommandFromResource(
        ConfirmPaymentIntentResource resource)
    {
        return new ConfirmPaymentIntentCommand(resource.PaymentIntentId);
    }
}