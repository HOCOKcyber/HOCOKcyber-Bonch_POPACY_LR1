using EquipmentManagement.Domain.Entities;

namespace EquipmentManagement.Domain.Repository;

public interface IRoomRepository
{
    Task<Room?> GetByIdAsync(int id);
    Task<IEnumerable<Room>> GetAllAsync();
    Task AddAsync(Room room);
    Task UpdateAsync(Room room);
    Task DeleteAsync(int id);
}