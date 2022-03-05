using Microsoft.EntityFrameworkCore;
using PackIt.Application.Services;
using PackIt.Infrasturcture.EF.Contexts;

namespace PackIt.Infrasturcture.EF.Services;

internal sealed class PostgresPackingListReadService : IPackingListReadService
{
    private readonly DbSet<PackingListReadModel> _packingLists;
    public PostgresPackingListReadService(ReadDbContext context) => _packingLists = context.PackingLists;
    public Task<bool> ExistsByNameAsync(string name) => _packingLists.AnyAsync(pl => pl.Name.Equals(name));
}
