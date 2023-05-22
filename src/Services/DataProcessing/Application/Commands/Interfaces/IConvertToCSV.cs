namespace DataProcessing.Application.Commands.Interfaces;
public interface IConvertToCSV<T>
{
    Task<string> ConvertAsync(IEnumerable<T> dto);
}