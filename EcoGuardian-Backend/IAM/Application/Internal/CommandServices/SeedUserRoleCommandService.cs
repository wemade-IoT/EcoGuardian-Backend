using EcoGuardian_Backend.IAM.Domain.Model.Commands;
using EcoGuardian_Backend.IAM.Domain.Model.Entities;
using EcoGuardian_Backend.IAM.Domain.Model.ValueObjects;
using EcoGuardian_Backend.IAM.Domain.Respositories;
using EcoGuardian_Backend.IAM.Domain.Services;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.IAM.Application.Internal.CommandServices;

public class SeedUserRoleCommandService(IUserRoleRepository repository, IUnitOfWork unitOfWork) : ISeedUserRoleCommandService
{
    public async Task Handle(SeedUserRolesCommand command)
    {
        foreach (EUserRoles role in Enum.GetValues(typeof(EUserRoles)))
        {
            if (await repository.ExistsUserRole(role)) continue;
            var userRole = new UserRole(role.ToString());
            await repository.AddAsync(userRole);
        }

        await unitOfWork.CompleteAsync();
    }
}