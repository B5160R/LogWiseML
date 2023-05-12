namespace DataProcessing.Application.Queries.Interfaces;
public interface IGetAllQuery<T>
{
    Task<IEnumerable<T>> GetAllAsync();
}