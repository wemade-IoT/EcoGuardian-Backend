﻿using EcoGuardian_Backend.Analytics.Domain.Model.Entities;
using EcoGuardian_Backend.Analytics.Domain.Model.ValueObjects;

namespace EcoGuardian_Backend.Analytics.Domain.Model.Aggregates;

public class MetricRegistry
{
    public int Id { get; private set; }
    public int DeviceId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public ICollection<Metric> Metrics { get; private set; } = new List<Metric>();
    public int AggregationLevelId { get; private set; }
    
    public AggregationLevel AggregationLevel { get; private set; }
    

    public MetricRegistry(int deviceId)
    {
        DeviceId = deviceId;
        CreatedAt = DateTime.UtcNow;
        AggregationLevelId = 1; //1 is the default aggregation level (None get all metrics)
    }

    public MetricRegistry(int deviceId, DateTime createdAt, ICollection<Metric> metrics, int aggregationLevelId)
    {
        DeviceId = deviceId;
        CreatedAt = createdAt;
        Metrics = metrics;
        AggregationLevelId = aggregationLevelId;
    }

    private MetricRegistry() { }
}
