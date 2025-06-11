namespace EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Commands;

public record UpdatePlantStateCommand(int StateId, int PlantId);