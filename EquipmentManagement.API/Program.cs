using EquipmentManagement.Infrastructure.Repositories;
using EquipmentManagement.Infrastructure.Data;
using EquipmentManagement.Domain.Repository;
using EquipmentManagement.API.Controller;
using EquipmentManagement.Presentation.Controllers;

var builder = WebApplication.CreateBuilder();

builder.WebHost.UseUrls("http://localhost:8080");
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<ISoftwareRepository, SoftwareRepository>();

builder.Services.AddControllers()
    .AddApplicationPart(typeof(EquipmentController).Assembly)
    .AddApplicationPart(typeof(RoomController).Assembly)
    .AddApplicationPart(typeof(SoftwareController).Assembly);

var app = builder.Build();
app.MapControllers();
await app.RunAsync();