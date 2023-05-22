using DataCollection.Application.Repositories;
using DataCollection.Application.Dtos;
using DataCollection.Domain.Models;
using DataCollection.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace DataCollection.Infrastructure.Repositories;
public class LogRepository : ILogRepository
{
    private readonly DataCollectionContext _context;
    public LogRepository(DataCollectionContext context)
    {
        _context = context;
    }

    public async Task<LogQueryResultDto> CreateAsync(LogModel entity)
    {
        await _context.Logs.AddAsync(entity);
        await _context.SaveChangesAsync();
        
        var createdEnity = _context.Logs.AsNoTracking().OrderByDescending(e => e.Id).FirstOrDefault();
         return new LogQueryResultDto
        {
            Id = createdEnity.Id,
            Content = createdEnity.Content,
        };
    }

    public IEnumerable<LogQueryResultDto> GetAllAsync()
    {
        foreach (var log in _context.Logs.AsNoTracking().ToList())
        {
            yield return new LogQueryResultDto
            {
                Id = log.Id,
                Content = log.Content,
            };
        }
    }
}