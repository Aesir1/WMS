using Microsoft.EntityFrameworkCore;
using WarehouseInfrastructure.Contexts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WarehouseDbContext>(optionsAction =>
    optionsAction.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();