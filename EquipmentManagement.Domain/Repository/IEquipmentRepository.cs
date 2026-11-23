using EquipmentManagement.Domain.Entities;

namespace EquipmentManagement.Domain.Repository;

public interface IEquipmentRepository
{
    Task<IEnumerable<Equipment>> GetAllAsync();
    Task<Equipment?> GetByIdAsync(int id);
    Task AddAsync(Equipment equipment);
    Task UpdateAsync(Equipment equipment);
    Task DeleteAsync(int id);
}