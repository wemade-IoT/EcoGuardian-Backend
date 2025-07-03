using EcoGuardian_Backend.Analytics.Domain.Model.Aggregates;
using EcoGuardian_Backend.Analytics.Domain.Model.Queries;
using EcoGuardian_Backend.Analytics.Domain.Repositories;
using EcoGuardian_Backend.Analytics.Domain.Services;

namespace EcoGuardian_Backend.Analytics.Application.Internal.QueryServices;

public class MetricRegistryQueryService(IMetricRegistryRepository metricRegistryRepository) : IMetricRegistryQueryService
{
    public async Task<IEnumerable<MetricRegistry>> Handle(GetMetricsRegistriesByDeviceIdQuery query)
    {
        return await metricRegistryRepository.GetMetricRegistriesByDeviceIdAsync(query.DeviceId);
    }
    
    public async Task<MetricRegistry?> Handle(GetLatestMetricRegistryByDeviceIdQuery query)
    {
        return await metricRegistryRepository.GetLatestMetricRegistryByDeviceIdAsync(query.DeviceId);
    }
}

