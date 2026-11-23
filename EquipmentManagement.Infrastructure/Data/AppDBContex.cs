using Microsoft.EntityFrameworkCore;
using EquipmentManagement.Domain.Entities;

namespace EquipmentManagement.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Equipment> Equipments {get; set;}
    public DbSet<Room> Rooms {get; set;}
    public DbSet<Software> Software {get; set;}
    
    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder
        )
    {
        optionsBuilder.UseSqlite("Data Source=equipment.db");
    }
}
