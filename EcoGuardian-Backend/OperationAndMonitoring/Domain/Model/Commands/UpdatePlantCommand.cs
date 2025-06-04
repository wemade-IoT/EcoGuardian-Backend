namespace EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Commands;

public record UpdatePlantCommand(
      int Id,
      string Type,
      int AreaCoverage,
      int UserId,
      double WaterThreshold,
      double LightThreshold,
      double TemperatureThreshold,
      bool IsPlantation,
      int WellnessStateId
    );