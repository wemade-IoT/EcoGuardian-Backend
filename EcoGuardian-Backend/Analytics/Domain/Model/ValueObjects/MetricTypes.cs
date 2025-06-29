using System.ComponentModel;

namespace EcoGuardian_Backend.Analytics.Domain.Model.ValueObjects;

public enum MetricTypes
{
    [Description("Humidity")]
    Humidity = 1,
    [Description("Light")]
    Light = 2,
    [Description("WaterConsumption")]
    WaterConsumption = 3,
    [Description("EnergyConsumption")]
    EnergyConsumption = 4
}
