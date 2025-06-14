using System.ComponentModel;

namespace EcoGuardian_Backend.IAM.Domain.Model.ValueObjects;

public enum EUserRoles
{
    [Description("Admin")]
    Admin =1,
    [Description("Domestic")]
    Domestic =2,
    [Description("Business")]
    Business =3,
    [Description("Specialist")]
    Specialist = 4,
}