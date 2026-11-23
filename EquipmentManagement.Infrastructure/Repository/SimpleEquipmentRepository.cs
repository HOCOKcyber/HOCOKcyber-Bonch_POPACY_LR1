using EquipmentManagement.Domain.Entities;
using EquipmentManagement.Domain.Repository;
using EquipmentManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace EquipmentManagement.Infrastructure.Repositories;

public class SimpleEquipmentRepository : IEquipmentRepository
{
    private readonly AppDbContext _context;

    public SimpleEquipmentRepository(AppDbContext context)
    {
        _context = context;
    }

    // Получить всё оборудование
    public async Task<IEnumerable<Equipment>> GetAllAsync()
    {
        return await _context.Equipments
            .AsNoTracking()
            .ToListAsync();
    }

    // Получить оборудование по ID
    public async Task<Equipment?> GetByIdAsync(int id)
    {
        return await _context.Equipments
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    // Добавить оборудование
    public async Task AddAsync(Equipment equipment)
    {
        await _context.Equipments.AddAsync(equipment);
        await _context.SaveChangesAsync();
    }

    // Обновить оборудование
    public async Task UpdateAsync(Equipment equipment)
    {
        _context.Equipments.Update(equipment);
        await _context.SaveChangesAsync();
    }

    // Удалить оборудование по ID
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
