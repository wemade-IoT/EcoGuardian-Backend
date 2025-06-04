using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Commands;

namespace EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;

public interface IPlantCommandService
{
    Task Handle(CreatePlantCommand command);
    Task Handle(UpdatePlantCommand command);
    Task Handle(DeletePlantCommand command);
}