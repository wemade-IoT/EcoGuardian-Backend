using EcoGuardian_Backend.Planning.Domain.Model.Commands;
using EcoGuardian_Backend.Planning.Domain.Model.Entities;
using EcoGuardian_Backend.Shared.Interfaces.Helpers;

namespace EcoGuardian_Backend.Planning.Domain.Model.Aggregates;

public class Order
{
    public int Id { get; }
    public string Action { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    public int StateId { get; private set; }
    public int ConsumerId { get; private set; }
    public int? SpecialistId { get; private set; }
    public DateTime? InstallationDate { get; private set; }
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public Order()
    {
        Action = string.Empty;
        CreatedAt = DateTimeConverterHelper.ToNormalizeFormat(DateTime.UtcNow);
        CompletedAt = null;
        StateId = 1;
        ConsumerId = 0;
        SpecialistId = null;
        InstallationDate = null;
    }

    public Order(CreateOrderCommand command)
    {
        Action = command.Action;
        CreatedAt = DateTimeConverterHelper.ToNormalizeFormat(DateTime.UtcNow);
        CompletedAt = null;
        StateId = 1;
        ConsumerId = command.ConsumerId;
        SpecialistId = null;
        InstallationDate = command.InstallationDate;
        OrderDetails = command.Details?.Select(d => new OrderDetail {
            DeviceId = d.DeviceId,
            Quantity = d.Quantity,
            UnitPrice = d.UnitPrice,
            Description = d.Description,
            OrderId = Id
        }).ToList() ?? new List<OrderDetail>();
    }

    public void Update(UpdateOrderCommand command)
    {
        Action = command.Action;
        CompletedAt = DateTimeConverterHelper.ToNormalizeFormat(DateTime.UtcNow);
        StateId = command.StateId;
        ConsumerId = command.ConsumerId;
        SpecialistId = command.SpecialistId;
        InstallationDate = command.InstallationDate;
    }

    public void CompletePayment()
    {
        StateId = 2;
    }

    public void CompleteInstallation()
    {
        StateId = 3;
        CompletedAt = DateTimeConverterHelper.ToNormalizeFormat(DateTime.UtcNow);
    }
}
