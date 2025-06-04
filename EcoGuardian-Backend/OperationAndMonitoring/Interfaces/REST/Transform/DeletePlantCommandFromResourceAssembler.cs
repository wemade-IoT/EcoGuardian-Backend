using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Commands;

namespace EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Transform;

public class DeletePlantCommandFromResourceAssembler
{
    public static DeletePlantCommand ToCommandFromResource(int id)
    {
        return new DeletePlantCommand(id);
    }
}