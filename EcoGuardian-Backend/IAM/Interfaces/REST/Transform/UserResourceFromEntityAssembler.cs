using System.Diagnostics;
using EcoGuardian_Backend.IAM.Domain.Model.Aggregates;
using EcoGuardian_Backend.IAM.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User? user)
    {
        Console.WriteLine("User Name is " + user?.Username);
        Debug.Assert(user != null, nameof(user) + " != null");
        return new UserResource(user.Id, user.Username);
    }
}