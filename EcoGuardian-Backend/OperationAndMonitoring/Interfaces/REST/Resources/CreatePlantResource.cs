namespace EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Resources;

public record CreatePlantResource(
    string Name,
    string Type,
    int AreaCoverage,
    int UserId,
    double WaterThreshold,
    double LightThreshold,
    double TemperatureThreshold,
    bool IsPlantation,
    int WellnessStateId
    );