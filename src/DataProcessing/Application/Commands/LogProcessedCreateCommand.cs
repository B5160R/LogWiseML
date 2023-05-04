using DataProcessing.Application.Commands.Interfaces;
using DataProcessing.Application.Dtos;

namespace DataProcessing.Application.Commands;
public class LogProcessedCreateCommand<T> : ICreateCommand<LogCreateRequestDto>
{
    public void Create(LogCreateRequestDto dto)
    {
        throw new NotImplementedException();
    }
}