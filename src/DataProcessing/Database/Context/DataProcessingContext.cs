using Microsoft.EntityFrameworkCore;
using DataProcessing.Domain.Models;

namespace DataProcessing.Database.Context;
public class DataProcessingContext : DbContext
{
    public DataProcessingContext(DbContextOptions<DataProcessingContext> options) : base(options)
    {
    }

    public DbSet<LogProcessedModel> LogsProcessed { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LogProcessedModel>().ToTable("LogsProcessed");
    }
}
