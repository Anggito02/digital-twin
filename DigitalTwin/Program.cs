using System.Text;
using AutoMapper;
using DigitalTwin.src;
using DigitalTwin.src.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DigitalTwinDBContext>(
    options => options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    )
);

// Automapper
var mapperConfiguration = new MapperConfiguration(conf =>
{
    conf.AddProfile(typeof(MappingProfile));
});

var mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
