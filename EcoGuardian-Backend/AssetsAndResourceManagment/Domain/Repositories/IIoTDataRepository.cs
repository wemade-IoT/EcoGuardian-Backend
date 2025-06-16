using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Entities;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.OperationAndMonitoring.Domain.Repositories;

public interface IIoTDataRepository : IBaseRepository<IoTData>
{
   
    Task<IEnumerable<IoTData>> GetByDeviceIdAsync(string deviceId);
    Task<IEnumerable<IoTData>> GetByDeviceIdAndTimeRangeAsync(string deviceId, DateTime startDate, DateTime endDate);
    
    Task<IEnumerable<IoTData>> GetByDeviceIdAndDataTypeAsync(string deviceId, string dataType);
}
