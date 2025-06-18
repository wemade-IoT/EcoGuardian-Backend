using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Commands;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Queries;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;

namespace EcoGuardian_Backend.OperationAndMonitoring.Interfaces.ACL.Service;

public class MonitorinContextFacade(IPlantCommandService plantCommandService, IPlantQueryService plantQueryService) : IMonitorinContextFacade
{
    public async Task<bool> CheckPlantExists(int plantId)
    {
        var query = new GetPlantByIdQuery(plantId);
        return await plantQueryService.Handle(query);
    }

    public void UpdatePlantState(int stateId, int plantId)
    {
        var command = new UpdatePlantStateCommand(stateId, plantId);
        plantCommandService.Handle(command);
    }
}