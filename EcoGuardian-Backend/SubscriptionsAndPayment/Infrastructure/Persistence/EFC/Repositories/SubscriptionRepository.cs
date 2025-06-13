using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Aggregates;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Infrastructure.Persistence.EFC.Repositories;

public class SubscriptionRepository(AppDbContext context) : BaseRepository<Subscription>(context), ISubscriptionRepository
{
    public async Task<Subscription?> FindByUserIdAsync(int userId)
    {
        return await context.Set<Subscription>()
            .FirstOrDefaultAsync(s => s.UserId == userId);
    }

    public async Task<IEnumerable<Subscription>> ListAllAsync()
    {
        return await context.Set<Subscription>()
            .ToListAsync();
    }

    public Task<Subscription?> FindByIdAsync(int id)
    {
        return context.Set<Subscription>()
            .FirstOrDefaultAsync(s => s.Id == id);
    }
}