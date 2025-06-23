namespace EcoGuardian_Backend.Resources.Domain.Model.Commands;

public record CreateDeviceCommand(
    string Type,
    int ConsumerId
);
