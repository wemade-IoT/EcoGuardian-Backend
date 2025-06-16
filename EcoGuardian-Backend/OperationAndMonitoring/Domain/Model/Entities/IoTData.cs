using System;
using EcoGuardian_Backend.Shared.Domain.Model;

namespace EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Entities;
public class IoTData : BaseModel
{
    public int Id { get; set; }
    public string DeviceId { get; set; } 
    public string DataType { get; set; }
    public string Value { get; set; } 
    public string Unit { get; set; } 
    public DateTime Timestamp { get; set; }

    public IoTData()
    {
    }

    public IoTData(string deviceId, string dataType, string value, string unit, DateTime timestamp)
    {
        DeviceId = deviceId;
        DataType = dataType;
        Value = value;
        Unit = unit;
        Timestamp = timestamp;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}
