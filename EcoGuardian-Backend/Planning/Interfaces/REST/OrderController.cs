using EcoGuardian_Backend.Planning.Domain.Model.Queries;
using EcoGuardian_Backend.Planning.Domain.Services;
using EcoGuardian_Backend.Planning.Interfaces.REST.Resources;
using EcoGuardian_Backend.Planning.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoGuardian_Backend.Planning.Interfaces.REST;

[Route("api/v1/[controller]")]
[ApiController]
[ProducesResponseType(500)]

public class OrderController(IOrderCommandService orderCommandService, IOrderQueryService orderQueryService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderResource resource)
    {
        var command = CreateOrderCommandFromResourceAssembler.ToCommandFromResource(resource);
        await orderCommandService.Handle(command);
        return StatusCode(StatusCodes.Status201Created, true);
    }
    
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderResource resource)
    {
        var command = UpdateOrderCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        await orderCommandService.Handle(command);
        return Ok(true);
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOrdersByUserId([FromQuery] int userId)
    {
        var query = new GetOrdersByUserIdQuery(userId);
        var orders = await orderQueryService.Handle(query);
        var resources = orders.Select(OrderResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }
}

