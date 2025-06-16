using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Aggregates;
using EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Transform;

public static class IoTDeviceResourceFromEntityTransformer
{

    public static IoTDeviceResource ToResource(IoTDevice entity)
    {
        return new IoTDeviceResource
        {
            Id = entity.Id,
            DeviceId = entity.DeviceId,
            Name = entity.Name,
            Type = entity.Type,
            Manufacturer = entity.Manufacturer,
            Model = entity.Model,
            FirmwareVersion = entity.FirmwareVersion,
            IsActive = entity.IsActive,
            Location = entity.Location,
            PlantId = entity.PlantId,
            UserId = entity.UserId,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt
        };
    }
    

    public static IEnumerable<IoTDeviceResource> ToResourceList(IEnumerable<IoTDevice> entities)
    {
        return entities.Select(ToResource);
    }
}
