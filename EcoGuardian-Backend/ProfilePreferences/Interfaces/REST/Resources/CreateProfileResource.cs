namespace EcoGuardian_Backend.ProfilePreferences.Interfaces.REST.Resources;

public record CreateProfileResource(string Name,string Username, string Email,string Address, string AvatarUrl, int UserId, int SubscriptionId);