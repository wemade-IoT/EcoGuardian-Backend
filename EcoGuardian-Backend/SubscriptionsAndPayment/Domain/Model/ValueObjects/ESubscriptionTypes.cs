using System.ComponentModel;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.ValueObjects;

public enum ESubscriptionTypes
{
    [Description("Domestic")]
    Domestic = 1,
    [Description("Pro")]
    Pro = 2,
    [Description("Enterprise")]
    Enterprise = 3,
}