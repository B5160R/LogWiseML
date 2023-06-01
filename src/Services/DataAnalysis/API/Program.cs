using DataAnalysis.API.Infrastructure.Consumer;
using MassTransit;
using RabbitMQ.Client;
using Shared.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x => 
{
    x.AddConsumer<LogErrorTimeModelResultConsumer>();
    x.UsingRabbitMq((context, config) =>
    {
        config.Host(RabbitMqConsts.Host, RabbitMqConsts.VirtualHost, h =>
        {
            h.Username(RabbitMqConsts.UserName);
            h.Password(RabbitMqConsts.Password);
        });
        config.ReceiveEndpoint("log-error-time-model-result", c =>
        {
            c.ConfigureConsumer<LogErrorTimeModelResultConsumer>(context);
        });
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
