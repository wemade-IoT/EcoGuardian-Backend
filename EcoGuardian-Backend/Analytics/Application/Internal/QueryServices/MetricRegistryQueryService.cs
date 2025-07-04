using EcoGuardian_Backend.Analytics.Domain.Model.Aggregates;
using EcoGuardian_Backend.Analytics.Domain.Model.Entities;
using EcoGuardian_Backend.Analytics.Domain.Model.Queries;
using EcoGuardian_Backend.Analytics.Domain.Model.ValueObjects;
using EcoGuardian_Backend.Analytics.Domain.Repositories;
using EcoGuardian_Backend.Analytics.Domain.Services;

namespace EcoGuardian_Backend.Analytics.Application.Internal.QueryServices;

public class MetricRegistryQueryService(IMetricRegistryRepository metricRegistryRepository, IAggregationLevelRepository aggregationLevelRepository) : IMetricRegistryQueryService
{
    public async Task<IEnumerable<MetricRegistry>> Handle(GetMetricsRegistriesByDeviceIdQuery query)
    {
        return await metricRegistryRepository.GetMetricRegistriesByDeviceIdAsync(query.DeviceId);
    }
    
    public async Task<MetricRegistry?> Handle(GetLatestMetricRegistryByDeviceIdQuery query)
    {
        return await metricRegistryRepository.GetLatestMetricRegistryByDeviceIdAsync(query.DeviceId);
    }

    public async Task<IEnumerable<MetricRegistry>> Handle(GetMetricRegistriesByPeriodQuery query)
    {
        var period = query.Period.ToLower();
        var aggregationLevel = await aggregationLevelRepository.GetByValueAsync(period);
        if (aggregationLevel == null)
            return new List<MetricRegistry>();
        int aggregationLevelId = aggregationLevel.Id;
        
        var existingAggregated = await metricRegistryRepository.GetMetricRegistriesByDeviceIdAsync(query.DeviceId);
        var filteredAggregated = existingAggregated
            .Where(r => r.AggregationLevelId == aggregationLevelId)
            .OrderBy(r => r.CreatedAt)
            .ToList();
        if (filteredAggregated.Any())
            return filteredAggregated;
        
        var registries = existingAggregated.Where(r => r.AggregationLevelId == (int)AggregationLevels.None).ToList();
        if (!registries.Any()) return new List<MetricRegistry>();
        List<MetricRegistry> aggregatedRegistries = new();
        if (period == "daily")
        {
            var grouped = registries.GroupBy(r => new { r.CreatedAt.Date, r.CreatedAt.Hour });
            foreach (var group in grouped)
            {
                var metrics = group.SelectMany(r => r.Metrics).GroupBy(m => m.MetricTypesId)
                    .Select(g => new Metric(g.Average(m => m.MetricValue), g.Key, 0)).ToList();
                var registry = new MetricRegistry(query.DeviceId, new DateTime(group.Key.Date.Year, group.Key.Date.Month, group.Key.Date.Day, group.Key.Hour, 0, 0), metrics, aggregationLevelId);
                aggregatedRegistries.Add(registry);
            }
        }
        else if (period == "weekly")
        {
            var grouped = registries.GroupBy(r => r.CreatedAt.Date);
            foreach (var group in grouped)
            {
                var metrics = group.SelectMany(r => r.Metrics).GroupBy(m => m.MetricTypesId)
                    .Select(g => new Metric(g.Average(m => m.MetricValue), g.Key, 0)).ToList();
                var registry = new MetricRegistry(query.DeviceId, group.Key, metrics, aggregationLevelId);
                aggregatedRegistries.Add(registry);
            }
        }
        else if (period == "monthly")
        {
            var grouped = registries.GroupBy(r => System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(r.CreatedAt, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday));
            foreach (var group in grouped)
            {
                var metrics = group.SelectMany(r => r.Metrics).GroupBy(m => m.MetricTypesId)
                    .Select(g => new Metric(g.Average(m => m.MetricValue), g.Key, 0)).ToList();
                var registry = new MetricRegistry(query.DeviceId, group.First().CreatedAt, metrics, aggregationLevelId);
                aggregatedRegistries.Add(registry);
            }
        }
        else
        {
            return new List<MetricRegistry>();
        }
        foreach (var agg in aggregatedRegistries)
            await metricRegistryRepository.AddAsync(agg);
        return aggregatedRegistries.OrderBy(r => r.CreatedAt);
    }
}
