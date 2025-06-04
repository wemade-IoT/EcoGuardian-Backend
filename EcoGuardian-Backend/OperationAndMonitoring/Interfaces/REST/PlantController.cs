
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Queries;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;
using EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Resources;
using EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST;


[ApiController]
[ProducesResponseType(500)]
[Route("api/v1/[controller]")]

public class PlantController(IPlantCommandService plantCommandService, IPlantQueryService plantQueryService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreatePlant([FromBody] CreatePlantResource resource)
    {
        var command = CreatePlantCommandFromResourceAssembler.ToCommandFromResource(resource);
        await plantCommandService.Handle(command);
        return StatusCode(201,true);
    }
    
    [HttpPut("{id:int}")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> UpdatePlant([FromBody] UpdatePlantResource resource, [FromRoute] int id)
    {
        var command = UpdatePlantCommandFromResourceAssembler.ToCommandFromResource(id,resource);
        await plantCommandService.Handle(command);
        return Ok(true);
    }
    
    [HttpDelete("{id:int}")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> DeletePlant([FromRoute] int id)
    {
        var command = DeletePlantCommandFromResourceAssembler.ToCommandFromResource(id);
        await plantCommandService.Handle(command);
        return Ok(true);
    }
    
    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetPlantsByUserId([FromQuery] int userId)
    {
        var query = new GetPlantsByUserIdQuery(userId);
        var plants = await plantQueryService.Handle(query);
        var resources = plants.Select(PlantResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }
}