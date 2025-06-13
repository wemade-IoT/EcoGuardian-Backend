using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Aggregates;
using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Queries;

namespace EcoGuardian_Backend.ProfilePreferences.Domain.Services;

public interface INotificationQueryService
{
    Task<IEnumerable<Notification>> Handle(GetNotificationsByProfileIdQuery query);
}