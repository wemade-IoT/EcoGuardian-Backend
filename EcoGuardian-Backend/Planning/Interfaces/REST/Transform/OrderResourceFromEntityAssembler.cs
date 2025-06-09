using EcoGuardian_Backend.Planning.Domain.Model.Aggregates;
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
            InstallationDate = order.InstallationDate
        };
    }
}