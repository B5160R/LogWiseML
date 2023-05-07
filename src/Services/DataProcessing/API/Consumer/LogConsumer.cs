using MassTransit;
using Shared.Models.Logs;

public class LogConsumer : IConsumer<LogRaw>
{
    public LogConsumer()
    {
    }
    
    public async Task Consume(ConsumeContext<LogRaw> context)
    {
        await Console.Out.WriteLineAsync($"Notification sent: log id: {context.Message.Id}");
        await Console.Out.WriteLineAsync($"Notification sent: log content: {context.Message.Content}");
    }
}