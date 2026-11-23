using EquipmentManagement.Domain.Enums;

namespace EquipmentManagement.Domain.Entities;

public class Equipment
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string InventoryNumber { get; set; } = string.Empty;
    public DateTime PurchaseDate { get; set; }
    public EquipmentStatus Status { get; set; }
    public string? Notes { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string ResponsiblePerson { get; set; } = string.Empty;
}