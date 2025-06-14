using EcoGuardian_Backend.Planning.Domain.Model.Commands;
using EcoGuardian_Backend.Planning.Domain.Model.Entities;
using EcoGuardian_Backend.Planning.Domain.Model.ValueObjects;
using EcoGuardian_Backend.Planning.Domain.Repositories;
using EcoGuardian_Backend.Planning.Domain.Services;
using EcoGuardian_Backend.Shared.Domain.Repositories;
using EcoGuardian_Backend.Shared.Interfaces.ASP.Configuration.Extensions;

namespace EcoGuardian_Backend.Planning.Application.Internal.CommandServices;

public class OrderStateCommandService(IUnitOfWork unitOfWork, IOrderStateRepository orderStateRepository) : IOrderStateCommandService
{
    public async Task Handle(SeedOrderStatesCommand command)
    {
        var existingOrderStates = Enum.GetValues(typeof(OrderStates)).Cast<OrderStates>();
        foreach (var orderState in existingOrderStates)
        {
            var type = orderState.GetDescription();
            var exists = await orderStateRepository.IsOrderStateTypeExistsAsync(type);
            if (exists) 
                continue;
            var newOrderState = new OrderState(type);
            await orderStateRepository.AddAsync(newOrderState);
            await unitOfWork.CompleteAsync();
        }
    }
}