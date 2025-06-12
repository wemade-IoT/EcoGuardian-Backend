using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Queries;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Services;
using EcoGuardian_Backend.SubscriptionsAndPayment.Interfaces.REST.Resources;
using EcoGuardian_Backend.SubscriptionsAndPayment.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Interfaces.REST;

[ApiController]
[ProducesResponseType(500)]
[Route("api/v1/[controller]")]
public class PaymentController(
    IPaymentCommandService paymentCommandService,
    IPaymentQueryService paymentQueryService)
    : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentResource resource)
    {
        var command = CreatePaymentCommandFromResourceAssembler.ToCommandFromResource(resource);
        await paymentCommandService.Handle(command);
        return StatusCode(201, true);
    }
    
    [HttpPost("payment-intent")]
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreatePaymentIntent([FromBody] CreatePaymentIntentResource resource)
    {
        var command = CreatePaymentIntentCommandFromResourceAssembler.ToCommandFromResource(resource);
        await paymentCommandService.Handle(command);
        return StatusCode(201, true);
    }
    
    [HttpPost("confirm-payment-intent")]
    [ProducesResponseType(201)]
    public async Task<IActionResult> ConfirmPaymentIntent([FromBody] ConfirmPaymentIntentResource resource)
    {
        var command = ConfirmPaymentIntentCommandFromResourceAssembler.ToCommandFromResource(resource);
        await paymentCommandService.Handle(command);
        return StatusCode(201, true);
    }
    
    [HttpGet("all")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetAllPayments()
    {
        var query = new GetAllPayments();
        var payments = await paymentQueryService.Handle(query);
        var resources = payments.Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }
    
    [HttpGet("{userId:int}")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetPaymentsByUserId([FromRoute] int userId)
    {
        var query = new GetPaymentsByUserId(userId);
        var payments = await paymentQueryService.Handle(query);
        var resources = payments.Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }
    
    [HttpGet("subscription-type")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetPaymentsBySubscriptionType([FromQuery] string subscriptionType)
    {
        var query = new GetPaymentsBySubscriptionType(subscriptionType);
        var payments = await paymentQueryService.Handle(query);
        var resources = payments.Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity).ToList();
        return Ok(resources);
    }
}