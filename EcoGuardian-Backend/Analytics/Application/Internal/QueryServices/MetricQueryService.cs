using EcoGuardian_Backend.Analytics.Domain.Model.Aggregates;
using EcoGuardian_Backend.Analytics.Domain.Model.Queries;
using EcoGuardian_Backend.Analytics.Domain.Repositories;
using EcoGuardian_Backend.Analytics.Domain.Services;

namespace EcoGuardian_Backend.Analytics.Application.Internal.QueryServices;

public class MetricQueryService(IMetricRepository metricRepository) : IMetricQueryService
{
    public async Task<IEnumerable<Metric>> Handle(GetMetricsByDeviceIdQuery query)
    {
        return await metricRepository.GetMetricsByDeviceIdAsync(query.DeviceId);
    }

    public async Task<IEnumerable<Metric>> Handle(GetMetricsByDeviceIdAndMetricTypeIdQuery query)
    {
        return await metricRepository.GetMetricsByDeviceIdAndMetricTypeIdAsync(query.DeviceId, query.MetricTypeId);
    }
}
