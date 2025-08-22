using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SellingClothesBackend.Data;
var builder = WebApplication.CreateBuilder(args);

// Configura Kestrel para escuchar en el puerto 80 en todas las interfaces (0.0.0.0)
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(80);
});

// Configura la cadena de conexión a la base de datos
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(connectionString));


// Agrega servicios para endpoints y para OpenAPI / Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Solo en desarrollo, habilita Swagger UI y JSON
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Mapea un endpoint simple para test
app.MapGet("/welcome", () => "Welcome to the Selling Clothes API!");

// Redirección HTTP a HTTPS (opcional, si usas HTTPS)
// Ten en cuenta que por simplicidad y para evitar complicaciones en Docker, puedes comentar esta línea si quieres usar solo HTTP
app.UseHttpsRedirection();

app.Run();
