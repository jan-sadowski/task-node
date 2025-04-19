using Microsoft.EntityFrameworkCore;
using TaskNode.Data;
using TaskNode.Mapping;
using TaskNode.Services;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Serwis ITodoService i jego implementacja TodoService
builder.Services.AddScoped<ITodoService, TodoService>();

// Automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Kontrolery
builder.Services.AddControllers();

var app = builder.Build();

// Obługa Http i Https
app.UseHttpsRedirection();

// Mapa kontrolerów
app.MapControllers();

// Start aplikacji 
app.Run();