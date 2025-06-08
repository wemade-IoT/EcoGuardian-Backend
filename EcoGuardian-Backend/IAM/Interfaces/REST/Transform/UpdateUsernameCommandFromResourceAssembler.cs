using EcoGuardian_Backend.IAM.Domain.Model.Commands;
using EcoGuardian_Backend.IAM.Interfaces.REST.Resources;

namespace EcoGuardian_Backend.IAM.Interfaces.REST.Transform;

public static class UpdateUsernameCommandFromResourceAssembler
{
    public static UpdateUsernameCommand ToUpdateUsernameCommand(int id,UpdateUsernameResource resource)
    {
        return new UpdateUsernameCommand(id,resource.Username);
    }
}