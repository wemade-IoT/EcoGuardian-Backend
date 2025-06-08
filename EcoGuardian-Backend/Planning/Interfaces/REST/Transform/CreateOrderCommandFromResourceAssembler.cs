using EcoGuardian_Backend.Planning.Domain.Model.Commands;
using EcoGuardian_Backend.Planning.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.Planning.Interfaces.REST.Transform;

public class CreateOrderCommandFromResourceAssembler
{
    public static CreateOrderCommand ToCommandFromResource(CreateOrderResource resource)
    {
        return new CreateOrderCommand(
            resource.Action,
            resource.UserId,
            resource.SensorId,
            resource.ActuatorId,
            resource.StateId,
            resource.SubscriptionId
        );
    }
}