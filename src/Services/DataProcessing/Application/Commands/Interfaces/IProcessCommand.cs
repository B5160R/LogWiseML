namespace DataProcessing.Application.Commands.Interfaces;
public interface IProcessCommand<T>
{
    Task ProcessAsync(T dto);
}