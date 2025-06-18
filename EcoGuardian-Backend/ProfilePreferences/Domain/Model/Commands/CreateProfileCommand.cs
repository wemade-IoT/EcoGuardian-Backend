namespace EcoGuardian_Backend.ProfilePreferences.Domain.Model.Commands;

public record CreateProfileCommand(string Email, string Name,string UserName, string Address,string AvatarUrl, int UserId, int SubscriptionId);