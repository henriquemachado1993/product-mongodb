using Microsoft.OpenApi.Models;
using ProductRegistrationMongoDB.Domain.Entities;
using ProductRegistrationMongoDB.Domain.Interfaces;
using ProductRegistrationMongoDB.Infra.Context;
using ProductRegistrationMongoDB.Infra.Dependencies;
using ProductRegistrationMongoDB.Infra.Repositories;
using ProductRegistrationMongoDB.Service;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Config access mongoDB
var mongoDBConfig = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBConfig>();
builder.Services.AddSingleton(mongoDBConfig);

// DependencyInjection
DependenciesInjector.Register(builder.Services);

// Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProductRegistrationMongoDB", Version = "v1" });

    // Adiciona a documentação XML gerada
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

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

// Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductRegistrationMongoDB V1");
});


app.Run();
