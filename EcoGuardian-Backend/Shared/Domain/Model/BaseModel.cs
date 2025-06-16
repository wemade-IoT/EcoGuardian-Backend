using System;

namespace EcoGuardian_Backend.Shared.Domain.Model;


public abstract class BaseModel
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
