using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Commands;
using EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.ValueObjects;

namespace EcoGuardian_Backend.SubscriptionsAndPayment.Domain.Model.Aggregates;

public class Payment
{
    public int Id { get; private set; }
    
    public string PaymentIntentId { get; set; }
    
    public string PaymentMethodId { get; private set; }
    
    public decimal Amount { get; private set; }
    
    public string Currency { get; private set; }
    
    public string PaymentStatus { get; set; }
    
    public int UserId { get; private set; }
    
    public int ReferenceId { get; set; }
    
    public EPaymentReferenceType ReferenceType { get; set; }
    
    public DateTime CreatedAt { get; private set; }
    
    public DateTime? UpdatedAt { get; private set; }

    public Payment()
    {
        CreatedAt = DateTime.UtcNow;
        PaymentStatus = "Pending";
        PaymentIntentId = string.Empty;
        PaymentMethodId = string.Empty;
        Currency = string.Empty;
        UpdatedAt = null;
        Amount = 0;
        UserId = 0;
        ReferenceId = 0;
        ReferenceType = EPaymentReferenceType.None;
    }

    public Payment(CreatePaymentCommand command)
    {
        PaymentIntentId = command.PaymentIntentId;
        PaymentMethodId = command.PaymentMethodId;
        Amount = command.Amount;
        Currency = command.Currency;
        PaymentStatus = command.PaymentStatus;
        UserId = command.UserId;
        ReferenceId = command.ReferenceId;
        ReferenceType = command.ReferenceType;
    }

    public Payment(CreatePaymentIntentCommand command)
    {
        Amount = command.Amount;
        Currency = command.Currency;
        PaymentMethodId = command.PaymentMethodId;
    }

    public Payment(ConfirmPaymentIntentCommand command)
    {
        PaymentIntentId = command.PaymentIntentId;
        PaymentStatus = "Confirmed";
    }
}