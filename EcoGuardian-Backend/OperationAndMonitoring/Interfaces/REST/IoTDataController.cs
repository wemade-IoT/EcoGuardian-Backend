using EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;
using EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Resources;
using EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class IoTDataController : ControllerBase
{
    private readonly IIoTDataService _dataService;

    public IoTDataController(IIoTDataService dataService)
    {
        _dataService = dataService;
    }
    

    [HttpPost]
    public async Task<ActionResult<IoTDataResource>> RegisterData([FromBody] CreateIoTDataResource resource)
    {
        try
        {
            var data = await _dataService.RegisterDataAsync(
                resource.DeviceId,
                resource.DataType,
                resource.Value,
                resource.Unit,
                resource.Timestamp);
            
            var result = IoTDataResourceFromEntityTransformer.ToResource(data);
            return Created($"/api/v1/IoTData/{result.Id}", result);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    

    [HttpGet("device/{deviceId}")]
    public async Task<ActionResult<IEnumerable<IoTDataResource>>> GetDataByDeviceId(string deviceId)
    {
        var data = await _dataService.GetDataByDeviceIdAsync(deviceId);
        var resources = IoTDataResourceFromEntityTransformer.ToResourceList(data);
        return Ok(resources);
    }
    

    [HttpGet("device/{deviceId}/timerange")]
    public async Task<ActionResult<IEnumerable<IoTDataResource>>> GetDataByTimeRange(
        string deviceId,
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate)
    {
        var data = await _dataService.GetDataByTimeRangeAsync(deviceId, startDate, endDate);
        var resources = IoTDataResourceFromEntityTransformer.ToResourceList(data);
        return Ok(resources);
    }
    

    [HttpGet("device/{deviceId}/type/{dataType}")]
    public async Task<ActionResult<IEnumerable<IoTDataResource>>> GetDataByType(string deviceId, string dataType)
    {
        var data = await _dataService.GetDataByTypeAsync(deviceId, dataType);
        var resources = IoTDataResourceFromEntityTransformer.ToResourceList(data);
        return Ok(resources);
    }
    

    [HttpDelete("device/{deviceId}/purge")]
    public async Task<ActionResult<int>> PurgeOldData(string deviceId, [FromQuery] DateTime olderThan)
    {
        var count = await _dataService.PurgeOldDataAsync(deviceId, olderThan);
        return Ok(new { deletedCount = count });
    }
}
