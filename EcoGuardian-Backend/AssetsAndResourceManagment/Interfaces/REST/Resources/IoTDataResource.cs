namespace EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Resources;


public class CreateIoTDataResource
{
    public string DeviceId { get; set; } = null!;
    public string DataType { get; set; } = null!;
    public string Value { get; set; } = null!;
    public string Unit { get; set; } = null!;
    public DateTime Timestamp { get; set; }
}


public class IoTDataResource
{
    public int Id { get; set; }
    public string DeviceId { get; set; } = null!;
    public string DataType { get; set; } = null!;
    public string Value { get; set; } = null!;
    public string Unit { get; set; } = null!;
    public DateTime Timestamp { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
