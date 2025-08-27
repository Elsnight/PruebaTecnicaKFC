using System.Reflection;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Api.Data;
using PruebaTecnica.Api.Services;
using PruebaTecnica.Api.Validators;
using Serilog;


var builder = WebApplication.CreateBuilder(args);


// Serilog para logs limpios en consola
builder.Host.UseSerilog((ctx, cfg) => cfg
.ReadFrom.Configuration(ctx.Configuration)
.WriteTo.Console());


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ======= EF Core =======
// Opción A: InMemory (rápido para correr sin DB)
builder.Services.AddDbContext<AppDbContext>(opt =>
opt.UseInMemoryDatabase("PruebaTecnicaDb"));


// Opción B: SQL Server (descomenta si deseas usar SQL)
// var cs = builder.Configuration.GetConnectionString("DefaultConnection");
// builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(cs));


// AutoMapper: registra perfiles del assembly
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


// FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<ClienteCreateDtoValidator>();


// Servicios de dominio
builder.Services.AddScoped<IClienteService, ClienteService>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.MapControllers();
app.Run();