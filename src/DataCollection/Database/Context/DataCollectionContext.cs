using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
using DataCollection.Domain.Models;
namespace DataCollection.Database.Context;
public class DataCollectionContext : DbContext
{
    public DataCollectionContext(DbContextOptions<DataCollectionContext> options) : base(options)
    {
    }

    public DbSet<LogModel> Logs { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataCollectionContext).Assembly);
    }
}