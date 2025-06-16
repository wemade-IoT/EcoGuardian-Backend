using System.Collections.Generic;
using System.Threading.Tasks;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Aggregates;

namespace EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;

public interface IIoTDeviceCommandService
{
    
    Task<IoTDevice> RegisterDeviceAsync(string deviceId, string name, string type, 
                                       string manufacturer, string model, 
                                       string firmwareVersion, string location, int userId);

    Task<IoTDevice> UpdateDeviceAsync(int id, string name, string type, string location, string firmwareVersion);
    
    
    Task<IoTDevice> ActivateDeviceAsync(int id);
    
    
    Task<IoTDevice> DeactivateDeviceAsync(int id);
    
    
    Task<IoTDevice> AssociateToPlantAsync(int id, int plantId);
    
    
    Task<IoTDevice> DisassociateFromPlantAsync(int id);
    
    
    Task<bool> DeleteDeviceAsync(int id);
}
