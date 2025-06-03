using EcoGuardian_Backend.OperationAndMonitoring.Domain.Model.Aggregates;
using EcoGuardian_Backend.OperationAndMonitoring.Domain.Repositories;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace EcoGuardian_Backend.OperationAndMonitoring.Infrastructure.Persistence.EFC.Repositories;

public class PlantRepository(AppDbContext context) : BaseRepository<Plant>(context), IPlantRepository
{
    
}