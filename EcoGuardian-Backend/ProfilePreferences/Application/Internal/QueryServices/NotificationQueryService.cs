using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Aggregates;
using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Queries;
using EcoGuardian_Backend.ProfilePreferences.Domain.Repositories;
using EcoGuardian_Backend.ProfilePreferences.Domain.Services;

namespace EcoGuardian_Backend.ProfilePreferences.Application.Internal.QueryServices;

public class NotificationQueryService(INotificationRepository notificationRepository) : INotificationQueryService
{
    public async Task<IEnumerable<Notification>> Handle(GetNotificationsByProfileIdQuery query)
    {
        return await notificationRepository.GetNotificationsByProfileIdAsync(query.ProfileId);
    }
}