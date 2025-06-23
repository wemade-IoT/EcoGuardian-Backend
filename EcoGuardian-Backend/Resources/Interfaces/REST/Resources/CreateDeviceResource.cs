namespace EcoGuardian_Backend.Resources.Interfaces.REST.Resources;

public record CreateDeviceResource(
    string Type,
    int ConsumerId
);
