namespace EcoGuardian_Backend.ProfilePreferences.Domain.Model.Commands;

public record CreateNotificationCommand(string Title, string Subject, int ProfileId);