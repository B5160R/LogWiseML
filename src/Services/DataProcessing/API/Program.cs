using DataProcessing.Application.Commands.Interfaces;
using DataProcessing.Application.Commands;
using DataProcessing.Application.Dtos;
using DataProcessing.Application.Repositories;
using DataProcessing.Database.Context;
using DataProcessing.Infrastructure.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Shared.Settings;
using DataProcessing.Application.Queries.Interfaces;
using DataProcessing.Application.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataProcessingContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DataProcessingDbConn"),
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

builder.Services.AddScoped<ILogProcessedRepository, LogProcessedRepository>();
builder.Services.AddScoped<ICreateCommand<LogProcessRequestDto>, LogProcessedCreateCommand<LogProcessRequestDto>>();
builder.Services.AddScoped<IGetAllQuery<LogQueryResultDto>, LogsGetAllQuery>();
builder.Services.AddScoped<IConvertToCSV<LogQueryResultDto>, LogsConvertToCSV>();

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
