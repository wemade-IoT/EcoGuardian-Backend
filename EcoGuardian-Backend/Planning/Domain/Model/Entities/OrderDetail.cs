namespace EcoGuardian_Backend.Planning.Domain.Model.Entities;

public class OrderDetail
{
    public int Id { get; set; } 
    public int OrderId { get; set; }
    public int DeviceId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public string? Description { get; set; }
    public decimal? Area { get; set; }
}
