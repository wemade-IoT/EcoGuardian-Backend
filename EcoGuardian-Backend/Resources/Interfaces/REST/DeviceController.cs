using EcoGuardian_Backend.Resources.Domain.Services;
using EcoGuardian_Backend.Resources.Interfaces.REST.Resources;
using EcoGuardian_Backend.Resources.Interfaces.REST.Transform;
using EcoGuardian_Backend.Shared.Interfaces.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoGuardian_Backend.Resources.Interfaces.REST;

[Route("api/v1/[controller]")]
[ApiController]
[ProducesResponseType(500)]
public class DeviceController(IDeviceCommandService deviceCommandService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [AuthorizeFilter("Admin", "Domestic", "Business")]
    public async Task<IActionResult> CreateDevice([FromBody] CreateDeviceResource resource)
    {
        var command = CreateDeviceCommandFromResourceAssembler.ToCommandFromResource(resource);
        await deviceCommandService.Handle(command);
        return StatusCode(StatusCodes.Status201Created, true);
    }
}
