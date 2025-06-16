using System.Collections.Generic;
using System.Threading.Tasks;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Aggregates;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.OperationAndMonitoring.Domain.Repositories;

public interface IIoTDeviceRepository : IBaseRepository<IoTDevice>
{
    
    Task<IEnumerable<IoTDevice>> GetByUserIdAsync(int userId);
    
    Task<IoTDevice?> GetByDeviceIdAsync(string deviceId);
    Task<IEnumerable<IoTDevice>> GetByPlantIdAsync(int plantId);
}
