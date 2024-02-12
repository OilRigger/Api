using ApiBack.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure DbContext to use MySQL with Pomelo.
builder.Services.AddDbContext<TiendaContext>((serviceProvider, options) =>
{
    var connectionString = builder.Configuration.GetConnectionString("TiendaDatabase");
    var serverVersion = new MySqlServerVersion(new Version(8, 0, 21)); // Ajusta a la versión de tu servidor MySQL.

    options.UseMySql(connectionString, serverVersion, mysqlOptions =>
    {
        // Otras configuraciones específicas de MySQL pueden ir aquí.
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
