using EcoGuardian_Backend.IAM.Domain.Model.Commands;

namespace EcoGuardian_Backend.IAM.Domain.Services;

public interface IRoleCommandService
{
    Task Handle(SeedUserRolesCommand command);
}