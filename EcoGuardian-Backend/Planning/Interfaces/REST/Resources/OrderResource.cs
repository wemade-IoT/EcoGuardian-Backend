namespace EcoGuardian_Backend.Planning.Interfaces.REST.Resources;

public record OrderResource
{
    public int Id { get; set; }
    public string Action { get; set; }
    public int UserId { get; set; }
    public int SensorId { get; set; }
    public int ActuatorId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public int StateId { get; set; }
    public int SubscriptionId { get; set; }
};