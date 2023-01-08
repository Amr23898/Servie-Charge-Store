using Microsoft.EntityFrameworkCore;
using System;

 using TaskPionner.Model;
using TaskPionner.Repositry;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepositoryService,ServiceRepository>();
 builder.Services.AddDbContext<ServicesDBContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("DatabasePath")));
builder.Services.AddCors(option => option.AddPolicy("corspolicy", build =>
{
    build.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
}
)); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("corspolicy");

app.MapControllers();

app.Run();
