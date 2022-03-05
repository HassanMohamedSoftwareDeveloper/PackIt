using Microsoft.EntityFrameworkCore;
using PackIt.Domain.ValueObjects;
using PackIt.Infrasturcture.EF.Contexts;

namespace PackIt.Infrasturcture.EF.Repositories;

internal sealed class PostgresPackingListRepository : IPackingListRepository
{
    private readonly DbSet<PackingList> _packingLists;
    private readonly WriteDbContext _writeDbContext;

    public PostgresPackingListRepository(WriteDbContext context)
    {
        _writeDbContext = context;
        _packingLists = context.PackingLists;
    }

    public Task<PackingList> GetAsync(PackingListId id)
    => _packingLists.Include("_items").SingleOrDefaultAsync(pl => pl.Id.Equals(id));

    public async Task AddAsync(PackingList packingList)
    {
        await _packingLists.AddAsync(packingList);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(PackingList packingList)
    {
        _packingLists.Update(packingList);
        await _writeDbContext.SaveChangesAsync();
    }
    public async Task DeleteAsync(PackingList packingList)
    {
        _packingLists.Remove(packingList);
        await _writeDbContext.SaveChangesAsync();
    }


}
