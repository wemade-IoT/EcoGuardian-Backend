using EcoGuardian_Backend.Planning.Domain.Model.Commands;
using EcoGuardian_Backend.Planning.Domain.Services;

namespace EcoGuardian_Backend.Planning.Interfaces.ACL.Service;

public class PlanningContextFacade(IOrderCommandService orderCommandService): IPlanningContextFacade
{
    public void UpdateOrderState(int orderId, int stateId)
    {
        var command = new UpdateOrderStateCommand(orderId, stateId);
        orderCommandService.Handle(command);
    }
}