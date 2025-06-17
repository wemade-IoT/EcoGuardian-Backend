using EcoGuardian_Backend.Shared.Domain.Repositories;
using EcoGuardian_Backend.Shared.Interfaces.ASP.Configuration.Extensions;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Commands;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Entities;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.ValueObjects;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Repositories;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Services;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Application.Internal.CommandServices;

public class SubscriptionTypeCommandService(
    IUnitOfWork unitOfWork,
    ISubscriptionTypeRepository subscriptionTypeRepository)
    : ISubscriptionTypeCommandService
{
    public async Task Handle(SeedSubscriptionTypesCommand command)
    {
        var subscriptionTypes = Enum.GetValues(typeof(ESubscriptionTypes)).Cast<ESubscriptionTypes>();
        foreach (var state in subscriptionTypes)
        {
            var type = state.GetDescription();
            var exists = await subscriptionTypeRepository.isSubcriptionTypeExistsAsync(type);
            if (exists) continue;
            var subscriptionType = new SubscriptionType(type);
            await subscriptionTypeRepository.AddAsync(subscriptionType);
            await unitOfWork.CompleteAsync();
        }
    }
}