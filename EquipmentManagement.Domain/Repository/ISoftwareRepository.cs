using EquipmentManagement.Domain.Entities;

namespace EquipmentManagement.Domain.Repository;
public interface ISoftwareRepository
{
    Task<Software?> GetByIdAsync(int id);
    Task<IEnumerable<Software>> GetAllAsync();
    Task AddAsync(Software software);
    Task UpdateAsync(Software software);
    Task DeleteAsync(int id);
}