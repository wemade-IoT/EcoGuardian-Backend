using EcoGuardian_Backend.Planning.Domain.Model.Commands;
using EcoGuardian_Backend.Shared.Interfaces.Helpers;

namespace EcoGuardian_Backend.Planning.Domain.Model.Aggregates;

public class Order
{
    public int Id { get; }
    public string Action { get; private set; }
    public int UserId { get; private set; }
    public int SensorId { get; private set; }
    public int ActuatorId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    public int StateId { get; private set; }
    public int SubscriptionId { get; private set; }

    public Order()
    {
        Action = string.Empty;
        UserId = 0;
        SensorId = 0;
        ActuatorId = 0;
        CreatedAt = DateTimeConverterHelper.ToNormalizeFormat(DateTime.UtcNow);
        CompletedAt = null;
        StateId = 0;
        SubscriptionId = 0;
    }

    public Order(CreateOrderCommand command)
    {
        Action = command.Action;
        UserId = command.UserId;
        SensorId = command.SensorId;
        ActuatorId = command.ActuatorId;
        CreatedAt = DateTimeConverterHelper.ToNormalizeFormat(DateTime.UtcNow);
        CompletedAt = null;
        StateId = command.OrderStateId;
        SubscriptionId = command.SubscriptionId;
    }
    
    public void Update(UpdateOrderCommand command)
    {
        Action = command.Action;
        UserId = command.UserId;
        SensorId = command.SensorId;
        ActuatorId = command.ActuatorId;
        CompletedAt = DateTimeConverterHelper.ToNormalizeFormat(DateTime.UtcNow);
        StateId = command.StateId;
        SubscriptionId = command.SubscriptionId;
    }
}