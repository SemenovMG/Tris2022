using Microsoft.EntityFrameworkCore;
using Tris2022.Infrastructure.Data;
using Tris2022.Interfaces;
using Tris2022.Interfaces.Services;
using Tris2022.Repositories;
using Tris2022.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddDbContext<DeansOfficeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Tris2022")));

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

app.MapControllers();

app.Run();
