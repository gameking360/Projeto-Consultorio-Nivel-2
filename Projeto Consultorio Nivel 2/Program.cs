global using Projeto_Consultorio_Nivel_2.Data;

using Microsoft.EntityFrameworkCore;
using Projeto_Consultorio_Nivel_2.Services;
using Projeto_Consultorio_Nivel_2.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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
