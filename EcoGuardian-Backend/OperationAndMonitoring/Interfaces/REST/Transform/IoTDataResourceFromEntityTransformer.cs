using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Entities;
using EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Transform;


public static class IoTDataResourceFromEntityTransformer
{

    public static IoTDataResource ToResource(IoTData entity)
    {
        return new IoTDataResource
        {
            Id = entity.Id,
            DeviceId = entity.DeviceId,
            DataType = entity.DataType,
            Value = entity.Value,
            Unit = entity.Unit,
            Timestamp = entity.Timestamp,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt
        };
    }
    

    public static IEnumerable<IoTDataResource> ToResourceList(IEnumerable<IoTData> entities)
    {
        return entities.Select(ToResource);
    }
}
