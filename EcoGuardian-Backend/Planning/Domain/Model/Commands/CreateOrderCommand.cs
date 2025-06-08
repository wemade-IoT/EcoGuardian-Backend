namespace EcoGuardian_Backend.Planning.Domain.Model.Commands;

public record CreateOrderCommand(
    string Action, 
    int UserId,
    int SensorId,
    int ActuatorId,
    int OrderStateId,
    int SubscriptionId
);