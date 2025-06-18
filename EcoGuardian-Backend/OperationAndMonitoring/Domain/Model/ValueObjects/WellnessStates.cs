using System.ComponentModel;

namespace EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.ValueObjects;

public enum WellnessStates
{
    [Description("Healthy")]
    Healthy = 1,
    [Description("Unhealthy")]
    Unhealthy = 2,
    [Description("Warning")]
    Warning = 3
}