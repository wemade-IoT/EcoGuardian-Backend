using EcoGuardian_Backend.Shared.Domain.Repositories;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Aggregates;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Commands;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Repositories;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Services;
using Stripe;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Application.Internal.CommandServices;

public class PaymentCommandService(
    IPaymentRepository paymentRepository,
    IUnitOfWork unitOfWork) 
    : IPaymentCommandService
{
    public async Task<Payment> Handle(CreatePaymentCommand command)
    {
        
        if (command.PaymentIntentId == null)
        {
            throw new ArgumentException("El PaymentIntentId no puede ser nulo.");
        }
        
        if (command.Amount <= 0)
        {
            throw new ArgumentException("El monto debe ser mayor que cero.");
        }

        var payment = new Payment(command);

        // guardamos el pago en la base de datos
        await paymentRepository.AddAsync(payment);
        await unitOfWork.CompleteAsync();

        return payment;
    }

    public async Task<string> Handle(CreatePaymentIntentCommand command)
    {
        if (command.Amount <= 0)
        {
            throw new ArgumentException("El monto debe ser mayor que cero.");
        }

        long amountInCents = (long)(command.Amount * 100);

        // creamoss un PaymentIntent con Stripe
        var options = new PaymentIntentCreateOptions
        {
            Amount = amountInCents,
            Currency = command.Currency,
            PaymentMethod = command.PaymentMethodId,
            ConfirmationMethod = "auto",
            Confirm = true,
            OffSession = true
        };

        // Configura la clave de API de Stripe
        var service = new PaymentIntentService();
        PaymentIntent paymentIntent = await service.CreateAsync(options);

        return paymentIntent.Id;
    }

    public async Task<string> Handle(ConfirmPaymentIntentCommand command)
    {
        var service = new PaymentIntentService();

        try
        {
            // obtenemos el PaymentIntent usando su ID
            var paymentIntent = await service.GetAsync(command.PaymentIntentId);

            var payment = await paymentRepository.FindByPaymentIntentIdAsync(paymentIntent.Id);

            if (payment != null)
            {
                payment.PaymentIntentId = paymentIntent.Id;
                payment.PaymentStatus = paymentIntent.Status;
                paymentRepository.Update(payment);
                await unitOfWork.CompleteAsync();
            }

            // devovlemos el estado del PaymentIntent (por eje: "succeeded", "failed", etc.)
            return paymentIntent.Status;
        }
        catch (StripeException ex)
        {
            throw new Exception($"Error al confirmar el PaymentIntent: {ex.Message}", ex);
        }
    }
}