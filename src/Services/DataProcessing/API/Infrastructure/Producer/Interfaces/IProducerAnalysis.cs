namespace DataProcessing.API.Infrastructure.Producer.Interfaces
{
    public interface IProducerAnalysis<T>
    {
        Task ProduceAsync(IEnumerable<T> dtos);
    }
}