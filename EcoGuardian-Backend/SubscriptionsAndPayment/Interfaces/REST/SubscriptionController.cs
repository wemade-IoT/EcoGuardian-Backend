using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Queries;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Services;
using EcoGuardian_Backend.SubscriptionsAndPayment.Interfaces.REST.Resources;
using EcoGuardian_Backend.SubscriptionsAndPayment.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Interfaces.REST;

[ApiController]
[ProducesResponseType(500)]
[Route("api/v1/[controller]")]
public class SubscriptionController(
    ISubscriptionCommandService subscriptionCommandService,
    ISubscriptionQueryService subscriptionQueryService)
    : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreatePayment([FromBody] CreateSubscriptionResource resource)
    {
        var command = CreateSubscriptionCommandFromResourceAssembler.ToCommandFromResource(resource);
        await subscriptionCommandService.Handle(command);
        return StatusCode(201, true);
    }

    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetAllSubscriptions()
    {
        var query = new GetAllSubscriptions();
        var payments = await subscriptionQueryService.Handle(query);
        var resources = payments.Select(SubscriptionResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }

    [HttpGet("user/{userId:int}")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetSubscriptionByUserId([FromRoute] int userId)
    {
        var query = new GetSubscriptionByUserIdQuery(userId);
        var subscription = await subscriptionQueryService.Handle(query);
        if (subscription == null) return NotFound();
        var resource = SubscriptionResourceFromEntityAssembler.ToResourceFromEntity(subscription);
        return Ok(resource);
    }

    [HttpGet("id/{subscriptionId:int}")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetSubscriptionById([FromRoute] int subscriptionId)
    {
        var query = new GetSubscriptionById(subscriptionId);
        var subscription = await subscriptionQueryService.Handle(query);
        if (subscription == null) return NotFound();
        var resource = SubscriptionResourceFromEntityAssembler.ToResourceFromEntity(subscription);
        return Ok(resource);
    }
}