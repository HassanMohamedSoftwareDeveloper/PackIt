using Microsoft.EntityFrameworkCore;
using PackIt.Domain.ValueObjects;
using PackIt.Infrasturcture.EF.Config;

namespace PackIt.Infrasturcture.EF.Contexts;

internal class WriteDbContext : DbContext
{
    public DbSet<PackingList> PackingLists { get; set; }
    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("packing");
        var configuration = new WriteConfiguration();
        modelBuilder.ApplyConfiguration<PackingList>(configuration);
        modelBuilder.ApplyConfiguration<PackingItem>(configuration);
    }
}
