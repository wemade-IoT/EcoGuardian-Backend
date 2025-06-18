namespace EcoGuardian_Backend.Analytics.Domain.Model.Entities;

public class MetricType
{
    public int Id { get; private set; }
    public string Type { get; private set; }

    public MetricType(string type)
    {
        Type = type;
    }
    
    private MetricType() { }
}

