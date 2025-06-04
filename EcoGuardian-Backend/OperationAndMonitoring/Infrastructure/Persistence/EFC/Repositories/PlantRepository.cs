using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Aggregates;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Repositories;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoGuardian_Backend.OperationAndMonitoring.Infrastructure.Persistence.EFC.Repositories;

public class PlantRepository(AppDbContext context) : BaseRepository<Plant>(context), IPlantRepository
{
    public async Task<IEnumerable<Plant>> GetPlantsByUserIdAsync(int userId)
    {
        return await context.Set<Plant>()
            .Where(p => p.UserId == userId)
            .ToListAsync();
    }
}