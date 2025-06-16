using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Entities;

namespace EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;

public interface IIoTDataService
{
   
    Task<IoTData> RegisterDataAsync(string deviceId, string dataType, string value, string unit, DateTime timestamp);
    
    Task<IEnumerable<IoTData>> GetDataByDeviceIdAsync(string deviceId);

    Task<IEnumerable<IoTData>> GetDataByTimeRangeAsync(string deviceId, DateTime startDate, DateTime endDate);
    
    Task<IEnumerable<IoTData>> GetDataByTypeAsync(string deviceId, string dataType);
    
    
    Task<int> PurgeOldDataAsync(string deviceId, DateTime olderThan);
}
