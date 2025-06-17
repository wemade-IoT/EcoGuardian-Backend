namespace EcoGuardian_Backend.Planning.Interfaces.ACL;

public interface IPlanningContextFacade
{
    void UpdateOrderState(int orderId, int stateId);
}