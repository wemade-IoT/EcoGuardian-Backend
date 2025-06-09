using EcoGuardian_Backend.Planning.Domain.Model.Aggregates;
using EcoGuardian_Backend.Planning.Domain.Model.Entities;
using EcoGuardian_Backend.Planning.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.Planning.Interfaces.REST.Transform;

public class OrderResourceFromEntityAssembler
{
    public static OrderResource ToResourceFromEntity(Order order)
    {
        return new OrderResource
        {
            Id = order.Id,
            Action = order.Action,
            CreatedAt = order.CreatedAt,
            CompletedAt = order.CompletedAt,
            StateId = order.StateId,
            ConsumerId = order.ConsumerId,
            SpecialistId = order.SpecialistId,
            InstallationDate = order.InstallationDate,
            Details = order.OrderDetails.Select(od => new OrderDetailResource(
                od.DeviceId,
                od.Quantity,
                od.UnitPrice,
                od.Description
            )).ToList()
        };
    }
}