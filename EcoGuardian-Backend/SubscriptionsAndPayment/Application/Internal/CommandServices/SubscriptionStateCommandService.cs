using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Commands;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Entities;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.ValueObjects;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Repositories;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Services;
using EcoGuardian_Backend.Shared.Domain.Repositories;
using EcoGuardian_Backend.Shared.Interfaces.ASP.Configuration.Extensions;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Application.Internal.CommandServices;

public class SubscriptionStateCommandService(IUnitOfWork unitOfWork 
    , ISubscriptionStateRepository subscriptionStateRepository)
    : ISubscriptionStateCommandService
{
    public async Task Handle(SeedSubscriptionStatesCommand command)
    {
        var subscriptionStates = Enum.GetValues(typeof(ESubscriptionStates)).Cast<ESubscriptionTypes>();
        foreach (var state in subscriptionStates)
        {
            var type = state.GetDescription();
            var exists = await subscriptionStateRepository.isSubcriptionStateExistsAsync(type);
            if (exists) continue;
            var subscriptionType = new SubscriptionState(type);
            await subscriptionStateRepository.AddAsync(subscriptionType);
            await unitOfWork.CompleteAsync();
        }
    }
}