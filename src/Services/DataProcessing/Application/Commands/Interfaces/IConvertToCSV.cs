namespace DataProcessing.Application.Commands.Interfaces;
public interface IConvertToCSV<T>
{
    Task<string> ConvertListAsync(IEnumerable<T> dto);
    Task<string> ConvertAsync(T dto);
}