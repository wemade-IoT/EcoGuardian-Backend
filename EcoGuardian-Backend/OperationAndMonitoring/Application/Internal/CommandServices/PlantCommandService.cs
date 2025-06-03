using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Aggregates;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Commands;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Repositories;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.OperationAndMonitoring.Application.Internal.CommandServices;

public class PlantCommandService(IPlantRepository plantRepository, IUnitOfWork unitOfWork) : IPlantCommandService
{
    public async Task Handle(CreatePlantCommand command)
    {
        var plant = new Plant(command);
        await plantRepository.AddAsync(plant);
        await unitOfWork.CompleteAsync();

    }
}