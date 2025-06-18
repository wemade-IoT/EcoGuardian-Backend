using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Entities;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.ValueObjects;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Infrastructure.Persistence.EFC.Repositories;

public class SubscriptionTypeRepository(AppDbContext context) : BaseRepository<SubscriptionType>(context), ISubscriptionTypeRepository
{
    public async Task<bool> isSubcriptionTypeExistsAsync(string? subscriptionType)
    {
        return await context.Set<SubscriptionType>()
            .AnyAsync(ws => ws.Type == subscriptionType);
    }
}