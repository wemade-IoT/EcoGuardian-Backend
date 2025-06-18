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

    public async Task Handle(UpdatePlantCommand command)
    {
        var plant = await plantRepository.GetByIdAsync(command.Id);
        if (plant == null)
        {
            throw new BadHttpRequestException($"Plant with ID {command.Id} not found.");
        }

        plant.Update(command);
        plantRepository.Update(plant);
        await unitOfWork.CompleteAsync();
    }

    public async Task Handle(DeletePlantCommand command)
    {
        var plant = await plantRepository.GetByIdAsync(command.Id);
        if (plant == null)
        {
            throw new BadHttpRequestException($"Plant with ID {command.Id} not found.");
        }

        plantRepository.DeleteAsync(plant);
        await unitOfWork.CompleteAsync();
    }
}