using Microsoft.EntityFrameworkCore;
using EquipmentManagement.Domain.Entities;

namespace EquipmentManagement.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Equipment> Equipments {get; set;}
    // public DbSet<EquipmentCategory> EquipmentCategories {get; set;}
    // public DbSet<Location> Locations {get; set;}
    // public DbSet<ResponsiblePerson> ResponsiblePersons {get; set;}
    
    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder
        )
    {
        optionsBuilder.UseSqlite("Data Source=equipment.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.Entity<Equipment>()
        //     .HasOne(e => e.Category)
        //     .WithMany(c => c.Equipments)
        //     .HasForeignKey(e => e.CategoryId)
        //     .OnDelete(DeleteBehavior.Restrict); 

        // modelBuilder.Entity<Equipment>()
        //     .HasOne(e => e.Location)
        //     .WithMany(l => l.Equipments)
        //     .HasForeignKey(e => e.LocationId)
        //     .OnDelete(DeleteBehavior.Restrict); 

        // modelBuilder.Entity<Equipment>()
        //     .HasOne(e => e.ResponsiblePerson)
        //     .WithMany(r => r.Equipments)
        //     .HasForeignKey(e => e.ResponsiblePersonId)
        //     .OnDelete(DeleteBehavior.Restrict);
    }
}
