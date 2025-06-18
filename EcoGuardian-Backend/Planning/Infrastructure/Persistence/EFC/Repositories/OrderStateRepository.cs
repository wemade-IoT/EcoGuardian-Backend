using EcoGuardian_Backend.Planning.Domain.Model.Entities;
using EcoGuardian_Backend.Planning.Domain.Repositories;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoGuardian_Backend.Planning.Infrastructure.Persistence.EFC.Repositories;

public class OrderStateRepository(AppDbContext context) : BaseRepository<OrderState>(context), IOrderStateRepository
{
    public async Task<bool> IsOrderStateTypeExistsAsync(string? type)
    {
        return await context.Set<OrderState>()
            .AnyAsync(x => x.Type == type);
    }
}