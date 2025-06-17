

using EcoGuardian_Backend.IAM.Domain.Model.Commands;
using EcoGuardian_Backend.IAM.Domain.Model.Queries;
using EcoGuardian_Backend.IAM.Domain.Services;

namespace EcoGuardian_Backend.IAM.Interfaces.ACL.Service;

public class IamContextFacade(IUserQueryService userQueryService, IUserCommandService commandService) : IIamContextFacade
{

    public async Task<bool> UsersExists(int userId)
    {
       var getUserByIdQuery = new GetUserByIdQuery(userId);
       var user = await userQueryService.Handle(getUserByIdQuery);
       return user != null;
    }

    public async Task UpdateRoleId(int userId, int roleId)
    {
        var command = new UpdateRoleCommand(roleId, userId);
        await commandService.Handle(command);
    }
}