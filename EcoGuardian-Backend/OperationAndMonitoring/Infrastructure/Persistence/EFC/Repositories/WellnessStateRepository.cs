using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Entities;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Repositories;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoGuardian_Backend.OperationAndMonitoring.Infrastructure.Persistence.EFC.Repositories;

public class WellnessStateRepository(AppDbContext context) : BaseRepository<WellnessState>(context), IWellnessStateRepository
{
    public async Task<bool> IsWellnessStateTypeExistsAsync(string? type)
    {
        return await context.Set<WellnessState>()
            .AnyAsync(ws => ws.Type == type);
    }
}