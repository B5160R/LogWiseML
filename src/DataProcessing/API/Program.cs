using DataProcessing.Database.Context;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using SharedModels;

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
