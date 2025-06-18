using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Commands;

namespace EcoGuardian_Backend.ProfilePreferences.Domain.Services;

public interface IProfileCommandService
{
    Task Handle(CreateProfileCommand command);
    Task Handle(UpdateProfileCommand command);
}