using DataProcessing.Application.Commands.Interfaces;
using DataProcessing.Application.Dtos;

namespace DataProcessing.Application.Commands;
public class LogProcessCommand<T> : IProcessCommand<LogProcessRequestDto>
{
    public Task ProcessAsync(LogProcessRequestDto dto)
    {
        throw new NotImplementedException();
    }
}