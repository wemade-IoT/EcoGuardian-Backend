using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Commands;
using EcoGuardian_Backend.Shared.Interfaces.Helpers;

namespace EcoGuardian_Backend.ProfilePreferences.Domain.Model.Aggregates;

public partial class Notification
{
    public int Id { get; }
    public string Title { get; private set; }
    public string Subject { get; private set; }
    public int ProfileId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    
    public Notification()
    {
        Title = string.Empty;
        Subject = string.Empty;
        ProfileId = 0;
        CreatedAt = DateTimeConverterHelper.ToNormalizeFormat(DateTime.UtcNow);
    }
    
    public Notification(CreateNotificationCommand command)
    {
        Title = command.Title;
        Subject = command.Subject;
        ProfileId = command.ProfileId;
        CreatedAt = DateTimeConverterHelper.ToNormalizeFormat(DateTime.UtcNow);
    }
    
    
}