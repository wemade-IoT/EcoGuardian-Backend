using EcoGuardian_Backend.Analytics.Domain.Model.Entities;

namespace EcoGuardian_Backend.Analytics.Domain.Repositories;

public interface IMetricTypeRepository
{
    Task<bool> IsMetricTypeExistsAsync(string type);
    Task AddAsync(MetricType metricType);
}

