using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Aggregates;
using EcoGuardian_Backend.ProfilePreferences.Domain.Model.Queries;

namespace EcoGuardian_Backend.ProfilePreferences.Domain.Services;

public interface IProfileQueryService
{
    Task<Profile?> Handle(GetProfileByEmailQuery query);
}