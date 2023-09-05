global using Projeto_Consultorio_Nivel_2.Services;
global using Microsoft.EntityFrameworkCore;
global using Projeto_Consultorio_Nivel_2.Models;
global using Projeto_Consultorio_Nivel_2.DTOs;
using Projeto_Consultorio_Nivel_2.Data;
using Projeto_Consultorio_Nivel_2.Services.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IMedicoInterface,MedicoService>();
//builder.Services.AddScoped<IPacienteService, PacienteService>();
//builder.Services.AddScoped<IConsultaService, ConsultaService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMedicoInterface, MedicoService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IConsultaService, ConsultaService>();


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
