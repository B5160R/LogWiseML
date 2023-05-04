namespace DataProcessing.Application.Commands.Interfaces;
public interface ICreateCommand<T>
{
    void Create(T dto);
}