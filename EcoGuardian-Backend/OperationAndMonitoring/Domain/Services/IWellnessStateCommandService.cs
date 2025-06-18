using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Commands;

namespace EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;

public interface IWellnessStateCommandService
{
    Task Handle(SeedWellnessStatesCommand command);
}