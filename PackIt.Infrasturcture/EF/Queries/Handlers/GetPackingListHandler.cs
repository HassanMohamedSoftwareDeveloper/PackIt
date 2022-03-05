using Microsoft.EntityFrameworkCore;
using PackIt.Infrasturcture.EF.Contexts;

namespace PackIt.Infrasturcture.EF.Queries.Handlers;

internal sealed class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDto>
{
    private readonly DbSet<PackingListReadModel> _packingLists;
    public GetPackingListHandler(ReadDbContext context) => _packingLists = context.PackingLists;
    public Task<PackingListDto> HandleAsync(GetPackingList query)
    => _packingLists.Include(pl => pl.Items)
        .Where(pl => pl.Id.Equals(query.Id))
        .Select(pl => pl.AsDto())
        .AsNoTracking()
        .SingleOrDefaultAsync();
}
