using EcoGuardian_Backend.Planning.Domain.Model.Commands;

namespace EcoGuardian_Backend.Planning.Domain.Services;

public interface IOrderStateCommandService
{
    Task Handle(SeedOrderStatesCommand command);
}