namespace DataProcessing.API.Infrastructure.Producer.Interfaces
{
    public interface IProducerAnalysis
    {
        Task ProduceAsync(string dto);
    }
}