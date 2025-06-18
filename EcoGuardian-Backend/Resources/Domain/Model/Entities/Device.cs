namespace EcoGuardian_Backend.Resources.Domain.Model.Entities;

public class Device
{
    public int Id { get; set; }
    public string DeviceId { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
}

