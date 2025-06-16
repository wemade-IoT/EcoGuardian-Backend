using System.Collections.Generic;
using System.Threading.Tasks;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Aggregates;

namespace EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;

public interface IIoTDeviceQueryService
{
    
    Task<IEnumerable<IoTDevice>> GetAllDevicesAsync();
    
    
    Task<IoTDevice?> GetDeviceByIdAsync(int id);
    
    
    Task<IoTDevice?> GetDeviceByDeviceIdAsync(string deviceId);
    
    
    Task<IEnumerable<IoTDevice>> GetDevicesByUserIdAsync(int userId);
    
    
    Task<IEnumerable<IoTDevice>> GetDevicesByPlantIdAsync(int plantId);
}
