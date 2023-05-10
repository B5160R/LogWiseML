using DataProcessing.Application.Dtos;
using DataProcessing.Application.Repositories;
using DataProcessing.Database.Context;
using DataProcessing.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataProcessing.Infrastructure.Repositories;
public class LogProcessedRepository : ILogProcessedRepository
{
    private readonly DataProcessingContext _context;

    public LogProcessedRepository(DataProcessingContext context)
    {
        _context = context;
    }
    
    public Task CreateAsync(LogProcessedModel entity)
    {
        try
        {
            _context.LogsProcessed.Add(entity);
            return _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public IEnumerable<LogQueryResultDto> GetAll()
    {
        foreach (var log in _context.LogsProcessed.AsNoTracking().ToList())
        {
            yield return new LogQueryResultDto(log.Id, 
                                               log.MLType, 
                                               log.Timestamp, 
                                               log.LogMessage, 
                                               log.ExceptionType, 
                                               log.Error, 
                                               log.Warning, 
                                               log.FaultyCodePlacement);
        }
    }
}