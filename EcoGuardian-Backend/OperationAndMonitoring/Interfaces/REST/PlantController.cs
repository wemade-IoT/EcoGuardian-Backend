
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Services;
using EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Resources;
using EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace EcoGuardian_Backend.OperationAndMonitoring.Interfaces.REST;


[ApiController]
[ProducesResponseType(500)]
[Route("api/v1/[controller]")]

public class PlantController(IPlantCommandService plantCommandService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreatePlant([FromBody] CreatePlantResource resource)
    {
        var command = CreatePlantCommandFromResourceAssembler.ToCommandFromResource(resource);
        await plantCommandService.Handle(command);
        return StatusCode(201,true);
    }
}