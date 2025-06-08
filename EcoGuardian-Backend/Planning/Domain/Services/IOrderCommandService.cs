using EcoGuardian_Backend.Planning.Domain.Model.Commands;

namespace EcoGuardian_Backend.Planning.Domain.Services;

public interface IOrderCommandService
{
    Task Handle(CreateOrderCommand command);
    Task Handle(UpdateOrderCommand command);
}