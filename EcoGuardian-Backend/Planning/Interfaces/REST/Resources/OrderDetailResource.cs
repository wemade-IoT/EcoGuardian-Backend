namespace EcoGuardian_Backend.Planning.Interfaces.REST.Resources;

public record OrderDetailResource(
    int DeviceId,
    int Quantity,
    decimal UnitPrice,
    string? Description
);

