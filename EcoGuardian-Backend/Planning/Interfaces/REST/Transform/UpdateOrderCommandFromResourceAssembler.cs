using EcoGuardian_Backend.Planning.Domain.Model.Commands;
using EcoGuardian_Backend.Planning.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.Planning.Interfaces.REST.Transform;

public class UpdateOrderCommandFromResourceAssembler
{
    public static UpdateOrderCommand ToCommandFromResource(int id, UpdateOrderResource resource)
    {
        return new UpdateOrderCommand(
            id,
            resource.Action,
            resource.StateId,
            resource.ConsumerId,
            resource.SpecialistId,
            resource.InstallationDate
        );
    }
}