namespace EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Entities;

public  class WellnessState
{
    public int Id { get; }
    public string Type { get; private set; }

    public WellnessState()
    {
        Type = string.Empty;
    }
    
    public WellnessState(string type)
    {
        Type = type;
    }
}