using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Aggregates;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Entities;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.ValueObjects;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Infrastructure.Persistence.EFC.Repositories;

public class SubscriptionStateRepository(AppDbContext context) : BaseRepository<SubscriptionState>(context), ISubscriptionStateRepository
{
    public async Task<bool> isSubcriptionStateExistsAsync(string? subscriptionState)
    {
        return await context.Set<SubscriptionState>()
            .AnyAsync(ws => ws.State == subscriptionState);
    }
}