using DataProcessing.Application.Repositories;
using DataProcessing.Database.Context;
using DataProcessing.Domain.Models;

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
}