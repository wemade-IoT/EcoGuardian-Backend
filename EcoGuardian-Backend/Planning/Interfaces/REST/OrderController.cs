using EcoGuardian_Backend.Planning.Domain.Model.Commands;
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
    public async Task<IActionResult> GetOrdersByConsumerId([FromQuery] int consumerId)
    {
        var query = new GetOrdersByConsumerIdQuery(consumerId);
        var orders = await orderQueryService.Handle(query);
        var resources = orders.Select(OrderResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }

    [HttpPut("{id:int}/complete-payment")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CompletePayment(int id)
    {
        var command = new CompletePaymentOrderCommand(id);
        await orderCommandService.Handle(command);
        return Ok(true);
    }

    [HttpPut("{id:int}/complete-installation")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CompleteInstallation(int id)
    {
        var command = new CompleteInstallationOrderCommand(id);
        await orderCommandService.Handle(command);
        return Ok(true);
    }
}
