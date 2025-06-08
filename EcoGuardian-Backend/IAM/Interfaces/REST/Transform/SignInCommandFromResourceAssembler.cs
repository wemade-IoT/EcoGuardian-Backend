using EcoGuardian_Backend.IAM.Domain.Model.Commands;
using EcoGuardian_Backend.IAM.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Email, resource.Password);
    }
}