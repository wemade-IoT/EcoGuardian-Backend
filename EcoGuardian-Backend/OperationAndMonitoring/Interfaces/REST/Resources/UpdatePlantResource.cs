namespace EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Resources;

public record UpdatePlantResource( 
    string Type,
    int AreaCoverage,
    int UserId,
    double WaterThreshold,
    double LightThreshold,
    double TemperatureThreshold,
    bool IsPlantation,
    int WellnessStateId
    );