using Microsoft.AspNetCore.Connections;
using Modelo.Aplication.Interface;
using Modelo.Application;
using Modelo.Infra;
using Modelo.Infra.Repositorio;
using Modelo.Infra.Repositorio.Interfaces;
using System.ComponentModel.Design;


var builder = WebApplication.CreateBuilder(args);

DbConnectionFactory dbConnectionFactory = new DbConnectionFactory(builder.Configuration);

builder.Services.AddSingleton(dbConnectionFactory);
builder.Services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
builder.Services.AddScoped<IAlunoApplication, AlunoApplication>();
builder.Services.AddHttpClient<ICepService, CepService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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