namespace EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Resources;


public class CreateIoTDeviceResource
{
    public string DeviceId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string FirmwareVersion { get; set; } = null!;
    public string Location { get; set; } = null!;
    public int? PlantId { get; set; }
}


public class UpdateIoTDeviceResource
{
    public string Name { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string FirmwareVersion { get; set; } = null!;
}


public class IoTDeviceResource
{
    public int Id { get; set; }
    public string DeviceId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string FirmwareVersion { get; set; } = null!;
    public bool IsActive { get; set; }
    public string Location { get; set; } = null!;
    public int? PlantId { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
