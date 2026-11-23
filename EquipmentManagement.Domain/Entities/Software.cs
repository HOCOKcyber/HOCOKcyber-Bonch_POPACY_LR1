
namespace EquipmentManagement.Domain.Entities;

public class Software
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
    public string LicenseKey { get; set; } = string.Empty;
    public DateTime? LicenseExpirationDate { get; set; }
    public int LicenseCount { get; set; }
    public string? Notes { get; set; }
    public string Category { get; set; } = string.Empty;
}