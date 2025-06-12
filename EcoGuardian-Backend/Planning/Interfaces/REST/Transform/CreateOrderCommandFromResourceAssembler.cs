using EcoGuardian_Backend.Planning.Domain.Model.Commands;
using EcoGuardian_Backend.Planning.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.Planning.Interfaces.REST.Transform;

public class CreateOrderCommandFromResourceAssembler
{
    public static CreateOrderCommand ToCommandFromResource(CreateOrderResource resource)
    {
        var details = resource.Details?.Select(d => new CreateOrderDetailCommand(
            d.DeviceId,
            d.Quantity,
            d.UnitPrice,
            d.Description,
            d.Area
        )).ToList() ?? new List<CreateOrderDetailCommand>();
        return new CreateOrderCommand(
            resource.Action,
            resource.ConsumerId,
            resource.InstallationDate,
            details
        );
    }
}