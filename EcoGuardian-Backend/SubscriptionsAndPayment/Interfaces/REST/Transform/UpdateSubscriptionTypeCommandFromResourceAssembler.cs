using UpdateSubscriptionTypeCommand = EcoGuardian_Backend.SubscriptionsAndPayment.Interfaces.REST.Resources.UpdateSubscriptionTypeCommand;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Interfaces.REST.Transform;

public class UpdateSubscriptionTypeCommandFromResourceAssembler
{
    public static UpdateSubscriptionTypeCommand ToCommandFromResource(
        UpdateSubscriptionTypeCommand command)
    {
        return new UpdateSubscriptionTypeCommand(
            command.Id,
            command.UserId,
            command.SubscriptionTypeId
        );
    }
}