namespace EcoGuardian_Backend.Resources.Domain.Model.Aggregates;

public class Device
{
    public int Id { get; set; }
    public string DeviceId { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
    public int ConsumerId { get; set; }
}

