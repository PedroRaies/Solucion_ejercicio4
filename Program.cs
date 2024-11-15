using Microsoft.EntityFrameworkCore;
using WebApi_TurnosPeluqueria.Models;
using WebApi_TurnosPeluqueria.Repositories;
using WebApi_TurnosPeluqueria.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);


//Config de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddDbContext<dbTurnosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbTurnosContext")));

builder.Services.AddScoped<IServicioRepository,ServicioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Aplicar politica de CORS
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
