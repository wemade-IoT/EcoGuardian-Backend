namespace EcoGuardian_Backend.Resources.Domain.Model.Commands;

public record CreateDeviceCommand(
    string Type,
    decimal Voltage,
    int PlantId
);
