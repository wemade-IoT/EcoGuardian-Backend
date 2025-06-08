using System.ComponentModel;

namespace EcoGuardian_Backend.Planning.Domain.Model.ValueObjects;

public enum OrderStates
{
    [Description("ToComplete")]
    ToComplete = 1,
    [Description("Completed")]
    Completed = 2,
}