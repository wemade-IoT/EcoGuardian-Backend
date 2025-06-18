using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Commands;

namespace EcoGuardian_Backend.ProfilePreferences.Domain.Model.Services;

public interface INotificationCommandService
{
    Task Handle(CreateNotificationCommand command);
}