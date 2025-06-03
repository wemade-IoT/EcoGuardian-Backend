using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Commands;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Entities;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.ValueObjects;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Repositories;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;
using EcoGuardian_Backend.Shared.Domain.Repositories;
using EcoGuardian_Backend.Shared.Interfaces.ASP.Configuration.Extensions;

namespace EcoGuardian_Backend.OperationAndMonitoring.Application.Internal.CommandServices;

public class WellnessCommandService(IUnitOfWork unitOfWork, IWellnessStateRepository wellnessStateRepository) : IWellnessStateCommandService
{
    public async Task Handle(SeedWellnessStatesCommand command)
    {
        var wellnessStates = Enum.GetValues(typeof(WellnessStates)).Cast<WellnessStates>();
        foreach (var state in wellnessStates)
        {
            var type = state.GetDescription();
            var exists = await wellnessStateRepository.IsWellnessStateTypeExistsAsync(type);
            if (exists) continue;
            var wellnessState = new WellnessState(type);
            await wellnessStateRepository.AddAsync(wellnessState);
            await unitOfWork.CompleteAsync();
        }
    }
}