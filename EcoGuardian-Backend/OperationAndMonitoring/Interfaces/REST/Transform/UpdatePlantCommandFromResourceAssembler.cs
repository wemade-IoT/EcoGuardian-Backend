using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Commands;
using EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Transform;

public class UpdatePlantCommandFromResourceAssembler
{
    public static UpdatePlantCommand ToCommandFromResource(int id,UpdatePlantResource resource)
    {
        return new UpdatePlantCommand(
            id,
            resource.Name,
            resource.Type,
            resource.AreaCoverage,
            resource.UserId,
            resource.WaterThreshold,
            resource.LightThreshold,
            resource.TemperatureThreshold,
            resource.IsPlantation,
            resource.WellnessStateId
        );
    }
}