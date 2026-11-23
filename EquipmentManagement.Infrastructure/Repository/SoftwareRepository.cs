
using EquipmentManagement.Domain.Entities;
using EquipmentManagement.Domain.Repository;
using EquipmentManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EquipmentManagement.Infrastructure.Repositories;

public class SoftwareRepository : ISoftwareRepository
{
    private readonly AppDbContext _context;

    public SoftwareRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Software>> GetAllAsync()
    {
        return await _context.Software
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Software?> GetByIdAsync(int id)
    {
        return await _context.Software
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddAsync(Software software)
    {
        await _context.Software.AddAsync(software);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Software software)
    {
        _context.Software.Update(software);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var software = await _context.Software
            .FirstOrDefaultAsync(s => s.Id == id);

        if (software != null)
        {
            _context.Software.Remove(software);
            await _context.SaveChangesAsync();
        }
    }
}
