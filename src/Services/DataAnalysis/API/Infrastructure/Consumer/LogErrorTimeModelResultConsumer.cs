
using MassTransit;

namespace DataAnalysis.API.Infrastructure.Consumer;

public class LogErrorTimeModelResultConsumer : IConsumer
{
    public async Task Consume(ConsumeContext context)
    {
        await Console.Out.WriteLineAsync($"Info: Received log from DataInput Gateway API");
        await Console.Out.WriteLineAsync($"      --- Log content: {context}");
    }
}