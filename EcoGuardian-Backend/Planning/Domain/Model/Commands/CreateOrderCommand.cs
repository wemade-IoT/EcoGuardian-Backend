namespace EcoGuardian_Backend.Planning.Domain.Model.Commands;

public record CreateOrderCommand(
    string Action,
    int ConsumerId,
    DateTime? InstallationDate,
    List<CreateOrderDetailCommand> Details
);