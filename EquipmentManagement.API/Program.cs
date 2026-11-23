using EquipmentManagement.Infrastructure.Repositories;
using EquipmentManagement.Infrastructure.Data;
using EquipmentManagement.Domain.Repository;
using EquipmentManagement.API.Controller;
using EquipmentManagement.Domain.Enums;
using EquipmentManagement.Domain.Entities;


// var db = new AppDbContext();

// var repo = new EquipmentRepository(db);

// var equipment = new Equipment
// {
//     Id = 1,
//     Name = "Ноутбук Lenovo ThinkPad",
//     InventoryNumber = "INV-001",
//     PurchaseDate = new DateTime(2025, 5, 15),
//     Status = EquipmentStatus.InUse,
//     Notes = "Используется в бухгалтерии",
//     CategoryId = 1,
//     LocationId = 1,
//     ResponsiblePersonId = 1
// };

// Console.WriteLine(equipment.Status);

// var eqs = await repo.GetAllAsync();

// Console.WriteLine(eqs.ToList()[0]);



var builder = WebApplication.CreateBuilder();

builder.WebHost.UseUrls("http://localhost:8080");
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IEquipmentRepository, SimpleEquipmentRepository>();


builder.Services.AddControllers().AddApplicationPart(typeof(EquipmentController).Assembly);;

var app = builder.Build();
app.MapControllers();
await app.RunAsync();
