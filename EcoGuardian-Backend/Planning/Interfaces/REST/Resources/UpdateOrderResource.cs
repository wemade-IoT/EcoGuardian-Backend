namespace EcoGuardian_Backend.Planning.Interfaces.REST.Resources;

public record UpdateOrderResource(
    string Action,
    int StateId,
    int ConsumerId,
    int? SpecialistId,
    DateTime? InstallationDate
);
