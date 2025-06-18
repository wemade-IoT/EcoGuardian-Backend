namespace EcoGuardian_Backend.Planning.Domain.Model.Entities;

public class OrderState
{
    public int Id { get; set; }
    public string Type { get; private set; }
    
    public OrderState()
    {
        Type = string.Empty;
    }
    
    public OrderState(string type)
    {
        Type = type;
    }
}