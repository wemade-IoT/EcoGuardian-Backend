namespace EcoGuardian_Backend.Planning.Interfaces.REST.Resources;

public record CreateOrderResource(
    string Action,
    int UserId,
    int SensorId,
    int ActuatorId,
    int StateId,
    int SubscriptionId
    );