using MassTransit;
using SharedModels;

public class LogConsumer : IConsumer<LogCreated>
{
    public LogConsumer()
    {
        
    }
    public async Task Consume(ConsumeContext<LogCreated> context)
    {
        await Console.Out.WriteLineAsync($"Notification sent: log id: {context.Message.Id}");
        await Console.Out.WriteLineAsync($"Notification sent: log content: {context.Message.Content}");
    }
}