using EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;
using EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Resources;
using EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class IoTDevicesController : ControllerBase
{
    private readonly IIoTDeviceCommandService _deviceCommandService;
    private readonly IIoTDeviceQueryService _deviceQueryService;

    public IoTDevicesController(IIoTDeviceCommandService deviceCommandService, 
                               IIoTDeviceQueryService deviceQueryService)
    {
        _deviceCommandService = deviceCommandService;
        _deviceQueryService = deviceQueryService;
    }
    

    [HttpGet]
    public async Task<ActionResult<IEnumerable<IoTDeviceResource>>> GetAllDevices()
    {
        var devices = await _deviceQueryService.GetAllDevicesAsync();
        var resources = IoTDeviceResourceFromEntityTransformer.ToResourceList(devices);
        return Ok(resources);
    }
    

    [HttpGet("{id:int}")]
    public async Task<ActionResult<IoTDeviceResource>> GetDeviceById(int id)
    {
        var device = await _deviceQueryService.GetDeviceByIdAsync(id);
        if (device == null)
            return NotFound();
        
        var resource = IoTDeviceResourceFromEntityTransformer.ToResource(device);
        return Ok(resource);
    }
    

    [HttpGet("deviceId/{deviceId}")]
    public async Task<ActionResult<IoTDeviceResource>> GetDeviceByDeviceId(string deviceId)
    {
        var device = await _deviceQueryService.GetDeviceByDeviceIdAsync(deviceId);
        if (device == null)
            return NotFound();
        
        var resource = IoTDeviceResourceFromEntityTransformer.ToResource(device);
        return Ok(resource);
    }
    

    [HttpGet("user/{userId:int}")]
    public async Task<ActionResult<IEnumerable<IoTDeviceResource>>> GetDevicesByUserId(int userId)
    {
        var devices = await _deviceQueryService.GetDevicesByUserIdAsync(userId);
        var resources = IoTDeviceResourceFromEntityTransformer.ToResourceList(devices);
        return Ok(resources);
    }
    

    [HttpGet("plant/{plantId:int}")]
    public async Task<ActionResult<IEnumerable<IoTDeviceResource>>> GetDevicesByPlantId(int plantId)
    {
        var devices = await _deviceQueryService.GetDevicesByPlantIdAsync(plantId);
        var resources = IoTDeviceResourceFromEntityTransformer.ToResourceList(devices);
        return Ok(resources);
    }
    

    [HttpPost]
    public async Task<ActionResult<IoTDeviceResource>> RegisterDevice([FromBody] CreateIoTDeviceResource resource)
    {
        try
        {
            var userId = User.Identity?.IsAuthenticated == true
                ? int.Parse(User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value ?? "0")
                : 0;
            
            if (userId == 0)
                return Unauthorized("Usuario no autenticado");
            
            var device = await _deviceCommandService.RegisterDeviceAsync(
                resource.DeviceId,
                resource.Name,
                resource.Type,
                resource.Manufacturer,
                resource.Model,
                resource.FirmwareVersion,
                resource.Location,
                userId);
            
            if (resource.PlantId.HasValue)
                await _deviceCommandService.AssociateToPlantAsync(device.Id, resource.PlantId.Value);
            
            var result = IoTDeviceResourceFromEntityTransformer.ToResource(device);
            return CreatedAtAction(nameof(GetDeviceById), new { id = result.Id }, result);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    

    [HttpPut("{id:int}")]
    public async Task<ActionResult<IoTDeviceResource>> UpdateDevice(int id, [FromBody] UpdateIoTDeviceResource resource)
    {
        try
        {
            var device = await _deviceCommandService.UpdateDeviceAsync(
                id,
                resource.Name,
                resource.Type,
                resource.Location,
                resource.FirmwareVersion);
            
            var result = IoTDeviceResourceFromEntityTransformer.ToResource(device);
            return Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }
    

    [HttpPatch("{id:int}/activate")]
    public async Task<ActionResult<IoTDeviceResource>> ActivateDevice(int id)
    {
        try
        {
            var device = await _deviceCommandService.ActivateDeviceAsync(id);
            var result = IoTDeviceResourceFromEntityTransformer.ToResource(device);
            return Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }
    

    [HttpPatch("{id:int}/deactivate")]
    public async Task<ActionResult<IoTDeviceResource>> DeactivateDevice(int id)
    {
        try
        {
            var device = await _deviceCommandService.DeactivateDeviceAsync(id);
            var result = IoTDeviceResourceFromEntityTransformer.ToResource(device);
            return Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }
    

    [HttpPatch("{id:int}/associate-plant/{plantId:int}")]
    public async Task<ActionResult<IoTDeviceResource>> AssociateToPlant(int id, int plantId)
    {
        try
        {
            var device = await _deviceCommandService.AssociateToPlantAsync(id, plantId);
            var result = IoTDeviceResourceFromEntityTransformer.ToResource(device);
            return Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }
    

    [HttpPatch("{id:int}/disassociate-plant")]
    public async Task<ActionResult<IoTDeviceResource>> DisassociateFromPlant(int id)
    {
        try
        {
            var device = await _deviceCommandService.DisassociateFromPlantAsync(id);
            var result = IoTDeviceResourceFromEntityTransformer.ToResource(device);
            return Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }
    

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDevice(int id)
    {
        var result = await _deviceCommandService.DeleteDeviceAsync(id);
        if (!result)
            return NotFound();
        
        return NoContent();
    }
}
