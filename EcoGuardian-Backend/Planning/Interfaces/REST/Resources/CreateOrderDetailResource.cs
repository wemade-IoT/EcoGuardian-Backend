namespace EcoGuardian_Backend.Planning.Interfaces.REST.Resources;

public record CreateOrderDetailResource(
    int DeviceId,
    int Quantity,
    decimal UnitPrice,
    string? Description
);

