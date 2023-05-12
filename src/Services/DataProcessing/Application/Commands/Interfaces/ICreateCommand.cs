namespace DataProcessing.Application.Commands.Interfaces;
public interface ICreateCommand<T>
{
    Task CreateAsync(T dto);
}