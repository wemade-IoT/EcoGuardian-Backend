using System.ComponentModel;

namespace EcoGuardian_Backend.Planning.Domain.Model.ValueObjects;

public enum OrderStates
{
    [Description("PaymentPending")]
    ToComplete = 1,
    [Description("InProcess")]
    Completed = 2,
    [Description("Completed")]
    Canceled = 3,
}