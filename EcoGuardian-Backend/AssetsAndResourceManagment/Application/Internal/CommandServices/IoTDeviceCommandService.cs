using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Aggregates;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Repositories;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.OperationAndMonitoring.Application.Internal.CommandServices;

public class IoTDeviceCommandService : IIoTDeviceCommandService
{
    private readonly IIoTDeviceRepository _iotDeviceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public IoTDeviceCommandService(IIoTDeviceRepository iotDeviceRepository, IUnitOfWork unitOfWork)
    {
        _iotDeviceRepository = iotDeviceRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IoTDevice> RegisterDeviceAsync(string deviceId, string name, string type, 
                                                   string manufacturer, string model, 
                                                   string firmwareVersion, string location, int userId)
    {
        // Verificar si ya existe un dispositivo con el mismo deviceId
        var existingDevice = await _iotDeviceRepository.GetByDeviceIdAsync(deviceId);
        if (existingDevice != null)
            throw new InvalidOperationException($"Ya existe un dispositivo con el ID {deviceId}");

        // Crear nuevo dispositivo
        var device = new IoTDevice(deviceId, name, type, manufacturer, model, firmwareVersion, location, userId);
        
        // Guardar en el repositorio
        await _iotDeviceRepository.AddAsync(device);
        await _unitOfWork.CompleteAsync();
        
        return device;
    }

    public async Task<IoTDevice> UpdateDeviceAsync(int id, string name, string type, string location, string firmwareVersion)
    {
        // Obtener el dispositivo
        var device = await _iotDeviceRepository.GetByIdAsync(id);
        if (device == null)
            throw new InvalidOperationException($"No se encontró el dispositivo con ID {id}");

        // Actualizar propiedades
        device.Update(name, type, location, firmwareVersion);
        
        // Guardar cambios
        _iotDeviceRepository.Update(device);
        await _unitOfWork.CompleteAsync();
        
        return device;
    }

    public async Task<IoTDevice> ActivateDeviceAsync(int id)
    {
        // Obtener el dispositivo
        var device = await _iotDeviceRepository.GetByIdAsync(id);
        if (device == null)
            throw new InvalidOperationException($"No se encontró el dispositivo con ID {id}");

        // Activar
        device.Activate();
        
        // Guardar cambios
        _iotDeviceRepository.Update(device);
        await _unitOfWork.CompleteAsync();
        
        return device;
    }

    public async Task<IoTDevice> DeactivateDeviceAsync(int id)
    {
        // Obtener el dispositivo
        var device = await _iotDeviceRepository.GetByIdAsync(id);
        if (device == null)
            throw new InvalidOperationException($"No se encontró el dispositivo con ID {id}");

        // Desactivar
        device.Deactivate();
        
        // Guardar cambios
        _iotDeviceRepository.Update(device);
        await _unitOfWork.CompleteAsync();
        
        return device;
    }

    public async Task<IoTDevice> AssociateToPlantAsync(int id, int plantId)
    {
        // Obtener el dispositivo
        var device = await _iotDeviceRepository.GetByIdAsync(id);
        if (device == null)
            throw new InvalidOperationException($"No se encontró el dispositivo con ID {id}");

        // Asociar a planta
        device.AssociateToPlant(plantId);
        
        // Guardar cambios
        _iotDeviceRepository.Update(device);
        await _unitOfWork.CompleteAsync();
        
        return device;
    }

    public async Task<IoTDevice> DisassociateFromPlantAsync(int id)
    {
        // Obtener el dispositivo
        var device = await _iotDeviceRepository.GetByIdAsync(id);
        if (device == null)
            throw new InvalidOperationException($"No se encontró el dispositivo con ID {id}");

        // Desasociar de planta
        device.DisassociateFromPlant();
        
        // Guardar cambios
        _iotDeviceRepository.Update(device);
        await _unitOfWork.CompleteAsync();
        
        return device;
    }

    public async Task<bool> DeleteDeviceAsync(int id)
    {
        // Obtener el dispositivo
        var device = await _iotDeviceRepository.GetByIdAsync(id);
        if (device == null)
            return false;

        // Eliminar
        _iotDeviceRepository.DeleteAsync(device);
        await _unitOfWork.CompleteAsync();
        
        return true;
    }
}