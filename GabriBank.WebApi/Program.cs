//using Application.Services;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.OpenApi.Models;
using Npgsql;
using System.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
string dbConnectionString = builder.Configuration.GetConnectionString("PostgreConnection");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<IDbConnection>((sp) => new NpgsqlConnection(dbConnectionString));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GabriBank", Version = "v1" });

    // Include the XML comments file
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var mapperConfig = new MapperConfiguration(cfg => {
    cfg.CreateMap<Domain.Entities.User, Application.Dtos.UserResponse>();
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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
