using EquipmentManagement.Domain.Entities;
using EquipmentManagement.Domain.Repository;
using EquipmentManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace EquipmentManagement.Infrastructure.Repositories;

public class EquipmentRepository : IEquipmentRepository
{
    private readonly AppDbContext _context;

    public EquipmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Equipment>> GetAllAsync()
    {
        return await _context.Equipments
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Equipment?> GetByIdAsync(int id)
    {
        return await _context.Equipments
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task AddAsync(Equipment equipment)
    {
        await _context.Equipments.AddAsync(equipment);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Equipment equipment)
    {
        _context.Equipments.Update(equipment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var equipment = await _context.Equipments
            .FirstOrDefaultAsync(e => e.Id == id);

        if (equipment != null)
        {
            _context.Equipments.Remove(equipment);
            await _context.SaveChangesAsync();
        }
    }
}
