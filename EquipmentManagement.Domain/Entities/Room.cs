using EquipmentManagement.Domain.Enums;


namespace EquipmentManagement.Domain.Entities;

public class Room
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Building { get; set; } = string.Empty;
    public int Floor { get; set; }
    public int Capacity { get; set; }
    public RoomType Type { get; set; }
    public string? Notes { get; set; }

      public ICollection<Equipment> Equipments { get; set; }
        = new List<Equipment>();
}