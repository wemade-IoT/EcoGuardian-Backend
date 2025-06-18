namespace EcoGuardian_Backend.Planning.Domain.Model.Commands;

public record UpdateOrderStateCommand
(
    int OrderId,
    int StateId
);