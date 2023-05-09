namespace DataProcessing.Application.Commands.Interfaces;
public interface ICreateCommand<T>
{
    Task Create(T dto);
}