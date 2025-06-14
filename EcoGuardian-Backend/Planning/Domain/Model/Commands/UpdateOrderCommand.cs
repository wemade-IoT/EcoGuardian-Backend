namespace EcoGuardian_Backend.Planning.Domain.Model.Commands;

public record UpdateOrderCommand(
    int Id, 
    string Action,
    int StateId,
    int ConsumerId,
    int? SpecialistId,
    DateTime? InstallationDate
);