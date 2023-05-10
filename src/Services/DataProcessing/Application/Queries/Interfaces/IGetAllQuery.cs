namespace DataProcessing.Application.Queries.Interfaces;
public interface IGetAllQuery<T>
{
    IEnumerable<T> GetAll();
}