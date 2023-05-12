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
    
    public async Task CreateAsync(LogProcessedModel entity)
    {
            await _context.LogsProcessed.AddAsync(entity);
            await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<LogQueryResultDto>> GetAllAsync()
    {
        var logs = await _context.LogsProcessed.AsNoTracking().ToListAsync();
        var dtoList = new List<LogQueryResultDto>();
        foreach (var log in logs)
        {
            dtoList.Add( new LogQueryResultDto(log.Id, 
                                               log.MLType, 
                                               log.Timestamp, 
                                               log.LogMessage, 
                                               log.ExceptionType, 
                                               log.Error, 
                                               log.Warning, 
                                               log.FaultyCodePlacement));
        }
        return dtoList;
    }
}