using System;
using EcoGuardian_Backend.Shared.Domain.Model;

namespace EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Aggregates;

public class IoTDevice : BaseModel
{
    public int Id { get; set; }
    public string DeviceId { get; set; } 
    public string Name { get; set; } 
    public string Type { get; set; } 
    public string Manufacturer { get; set; } 
    public string Model { get; set; } 
    public string FirmwareVersion { get; set; } 
    public bool IsActive { get; set; } 
    public string Location { get; set; } 
    public int? PlantId { get; set; } 
    public int UserId { get; set; } 

    public IoTDevice()
    {}

    public IoTDevice(string deviceId, string name, string type, string manufacturer, 
                    string model, string firmwareVersion, string location, int userId)
    {
        DeviceId = deviceId;
        Name = name;
        Type = type;
        Manufacturer = manufacturer;
        Model = model;
        FirmwareVersion = firmwareVersion;
        IsActive = true;
        Location = location;
        UserId = userId;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Activate()
    {
        IsActive = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AssociateToPlant(int plantId)
    {
        PlantId = plantId;
        UpdatedAt = DateTime.UtcNow;
    }

    public void DisassociateFromPlant()
    {
        PlantId = null;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Update(string name, string type, string location, string firmwareVersion)
    {
        Name = name;
        Type = type;
        Location = location;
        FirmwareVersion = firmwareVersion;
        UpdatedAt = DateTime.UtcNow;
    }
}
