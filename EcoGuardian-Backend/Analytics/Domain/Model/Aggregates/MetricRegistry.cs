namespace EcoGuardian_Backend.Analytics.Domain.Model.Aggregates;

public class MetricRegistry
{
    public int Id { get; private set; }
    public int DeviceId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public ICollection<Metric> Metrics { get; private set; } = new List<Metric>();

    public MetricRegistry(int deviceId)
    {
        DeviceId = deviceId;
        CreatedAt = DateTime.UtcNow;
    }

    private MetricRegistry() { }
}

