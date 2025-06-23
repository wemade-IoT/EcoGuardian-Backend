using EcoGuardian_Backend.Resources.Domain.Model.Aggregates;
using EcoGuardian_Backend.Resources.Domain.Repositories;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.Resources.Infrastructure.Persistence.EFC.Repositories;

public class DeviceRepository : IDeviceRepository, IBaseRepository<Device>
{
    private readonly AppDbContext _context;
    public DeviceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Device?> GetByIdAsync(int id)
    {
        return await _context.Set<Device>().FindAsync(id);
    }

    public async Task<IEnumerable<Device>> GetAllAsync()
    {
        return await _context.Set<Device>().ToListAsync();
    }

    public async Task<bool> AddAsync(Device entity)
    {
        await _context.Set<Device>().AddAsync(entity);
        return true;
    }

    public void Update(Device entity)
    {
        _context.Set<Device>().Update(entity);
    }

    public void DeleteAsync(Device entity)
    {
        _context.Set<Device>().Remove(entity);
    }
}
