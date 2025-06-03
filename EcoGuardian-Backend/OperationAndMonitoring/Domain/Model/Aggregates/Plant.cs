using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Commands;
using EcoGuardian_Backend.Shared.Interfaces.Helpers;

namespace EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Aggregates;

public class Plant
{
    public int Id { get; }
    public string Type { get; private set; }
    public int AreaCoverage { get; private set; }
    public int UserId { get; private set; }
    public double WaterThreshold { get; private set; }
    public double LightThreshold { get; private set; }
    public double TemperatureThreshold { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public bool IsPlantation { get; private set; }
    public int WellnessStateId { get; private set; }

    public Plant()
    {
        Type = string.Empty;
        AreaCoverage = 0;
        UserId = 0;
        WaterThreshold = 0.0;
        LightThreshold = 0.0;
        TemperatureThreshold = 0.0;
        CreatedAt = DateTimeConverterHelper.ToNormalizeFormat(DateTime.UtcNow);
        UpdatedAt = null;
        IsPlantation = false;
        WellnessStateId = 0;
    }

    public Plant(CreatePlantCommand command)
    {
        Type = command.Type;
        AreaCoverage = command.AreaCoverage;
        UserId = command.UserId;
        WaterThreshold = command.WaterThreshold;
        LightThreshold = command.LightThreshold;
        TemperatureThreshold = command.TemperatureThreshold;
        CreatedAt = DateTimeConverterHelper.ToNormalizeFormat(DateTime.UtcNow);
        UpdatedAt = null;
        IsPlantation = command.IsPlantation;
        WellnessStateId = command.WellnessStateId;
    }
    
}