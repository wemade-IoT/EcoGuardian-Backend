namespace EcoGuardian_Backend.Planning.Domain.Model.Commands;

public record CreateOrderDetailCommand(
    int DeviceId,
    int Quantity,
    decimal UnitPrice,
    string? Description
);

