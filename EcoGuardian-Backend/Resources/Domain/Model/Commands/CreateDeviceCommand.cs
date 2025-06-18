namespace EcoGuardian_Backend.Resources.Domain.Model.Commands;

public record CreateDeviceCommand(
    string DeviceId,
    int ConsumerId
);
