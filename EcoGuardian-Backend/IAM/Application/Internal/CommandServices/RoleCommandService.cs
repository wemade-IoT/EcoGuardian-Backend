using EcoGuardian_Backend.IAM.Domain.Model.Commands;
using EcoGuardian_Backend.IAM.Domain.Model.Entities;
using EcoGuardian_Backend.IAM.Domain.Model.ValueObjects;
using EcoGuardian_Backend.IAM.Domain.Respositories;
using EcoGuardian_Backend.IAM.Domain.Services;
using EcoGuardian_Backend.Shared.Domain.Repositories;
using EcoGuardian_Backend.Shared.Interfaces.ASP.Configuration.Extensions;

namespace EcoGuardian_Backend.IAM.Application.Internal.CommandServices;

public class RoleCommandService(IUserRoleRepository repository, IUnitOfWork unitOfWork) : IRoleCommandService
{
    public async Task Handle(SeedUserRolesCommand command)
    {
        foreach (EUserRoles role in Enum.GetValues(typeof(EUserRoles)))
        {
            if (await repository.ExistsUserRole(role.GetDescription())) continue;
            var userRole = new UserRole(role.ToString());
            await repository.AddAsync(userRole);
        }

        await unitOfWork.CompleteAsync();
    }
}