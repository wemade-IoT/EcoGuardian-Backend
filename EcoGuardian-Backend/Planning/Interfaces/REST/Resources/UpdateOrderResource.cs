namespace EcoGuardian_Backend.Planning.Interfaces.REST.Resources;

public record UpdateOrderResource(
    string Action,
    int UserId,
    int SensorId,
    int ActuatorId,
    int StateId,
    int SubscriptionId
    );