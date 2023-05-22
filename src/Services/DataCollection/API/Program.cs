using DataCollection.API.Infrastructure.Producer;
using DataCollection.API.Infrastructure.Consumer;
using DataCollection.Application.Commands.Interfaces;
using DataCollection.Application.Commands;
using DataCollection.Application.Dtos;
using DataCollection.Application.Queries.Interfaces;
using DataCollection.Application.Queries;
using DataCollection.Application.Repositories;
using DataCollection.Infrastructure.Repositories;
using DataCollection.Database.Context;
using Microsoft.EntityFrameworkCore;
using MassTransit;
using Shared.Settings;
using DataCollection.API.Infrastructure.Producer.Interfaces;
using Shared.Models.Logs;
using MassTransit.Transports.Fabric;

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
    x.AddConsumer<LogConsumer>();
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
builder.Services.AddScoped<ICreateCommand<LogCreateRequestDto>, LogCreateCommand>();
builder.Services.AddScoped<IProducer, LogProducer>();

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
