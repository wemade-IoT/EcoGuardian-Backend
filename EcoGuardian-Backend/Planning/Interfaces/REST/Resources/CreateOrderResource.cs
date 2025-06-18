namespace EcoGuardian_Backend.Planning.Interfaces.REST.Resources;

public record CreateOrderResource(
    string Action,
    int ConsumerId,
    DateTime? InstallationDate,
    List<CreateOrderDetailResource> Details
);

