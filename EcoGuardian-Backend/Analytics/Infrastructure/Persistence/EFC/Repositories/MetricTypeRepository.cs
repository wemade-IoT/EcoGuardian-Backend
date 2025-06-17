using EcoGuardian_Backend.Analytics.Domain.Model.Entities;
using EcoGuardian_Backend.Analytics.Domain.Repositories;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoGuardian_Backend.Analytics.Infrastructure.Persistence.EFC.Repositories;

public class MetricTypeRepository(AppDbContext context) : BaseRepository<MetricType>(context), IMetricTypeRepository
{
    public async Task<bool> IsMetricTypeExistsAsync(string type)
    {
        return await context.Set<MetricType>()
            .AnyAsync(x => x.Type == type);
    }

    public async Task AddAsync(MetricType metricType)
    {
        await context.Set<MetricType>().AddAsync(metricType);
    }
}

