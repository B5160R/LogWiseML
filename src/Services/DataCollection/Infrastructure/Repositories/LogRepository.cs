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

    public Task CreateAsync(LogModel entity)
    {
        _context.Logs.Add(entity);
        return _context.SaveChangesAsync();
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