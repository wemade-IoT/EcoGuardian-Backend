using System.ComponentModel;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.ValueObjects;

public enum ESubscriptionStates
{
    [Description("Active")]
    Active = 1,
    [Description("Inactive")]
    Inactive = 2
}