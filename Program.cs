using Microsoft.EntityFrameworkCore;
using TaskNode.Data;
using TaskNode.Services;

var builder = WebApplication.CreateBuilder(args);

// Zarejestruj DbContext
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Zarejestruj serwis ITodoService oraz jego implementację TodoService
builder.Services.AddScoped<ITodoService, TodoService>();

// Dodaj kontrolery
builder.Services.AddControllers();

var app = builder.Build();

// Konfiguracja Kestrela do obsługi HTTP i HTTPS
app.UseHttpsRedirection();

// Mapa kontrolerów
app.MapControllers();

// Uruchomienie aplikacji
app.Run();

// testsfdsf