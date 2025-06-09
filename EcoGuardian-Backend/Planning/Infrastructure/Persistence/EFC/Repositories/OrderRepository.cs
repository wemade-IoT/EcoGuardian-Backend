using EcoGuardian_Backend.Planning.Domain.Model.Aggregates;
using EcoGuardian_Backend.Planning.Domain.Repositories;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoGuardian_Backend.Planning.Infrastructure.Persistence.EFC.Repositories;

public class OrderRepository(AppDbContext context) : BaseRepository<Order>(context), IOrderRepository
{
    public async Task<IEnumerable<Order>> GetOrdersByConsumerIdAsync(int consumerId)
    {
        return await context.Set<Order>()
            .Where(x => x.ConsumerId == consumerId)
            .ToListAsync();
    }
}