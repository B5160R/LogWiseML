using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Sqlite;
using DataCollection.Database.Context;
using DataCollection.Domain.Models;
using DataCollection.Application.Queries.Interfaces;
using DataCollection.Application.Queries;
using DataCollection.Application.Repositories;
using DataCollection.Infrastructure.Repositories;
using DataCollection.Application.Commands.Interfaces;
using DataCollection.Application.Commands;
using DataCollection.Application.Dtos;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using MassTransit;
using SharedModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataCollectionContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DataCollectionDbConn"),
    b=>b.MigrationsAssembly("Migrations"));
});

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, config)=>
    {
        config.Host(RabbitMqConsts.Host, RabbitMqConsts.VirtualHost, h => 
        {                        
            h.Username(RabbitMqConsts.UserName);                        
            h.Password(RabbitMqConsts.Password);
        });
        config.ConfigureEndpoints(context);
    });
});

builder.Services.AddScoped<ILogRepository, LogRepository>();
builder.Services.AddScoped<IGetAllQuery<IEnumerable<LogQueryResultDto>>, LogGetAllQuery>();
builder.Services.AddScoped<ICreateCommand<LogCreateRequestDto>, LogCreateCommand<LogCreateRequestDto>>();
builder.Services.AddScoped<ILogParserCommand, LogParserCommand>();


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
