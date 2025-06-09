namespace EcoGuardian_Backend.Planning.Interfaces.REST.Resources;

public record OrderResource
{
    public int Id { get; set; }
    public string Action { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public int StateId { get; set; }
    public int ConsumerId { get; set; }
    public int? SpecialistId { get; set; }
    public DateTime? InstallationDate { get; set; }
    public List<OrderDetailResource> Details { get; set; }
    
};