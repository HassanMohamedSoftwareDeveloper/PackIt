namespace PackIt.Application.Queries.Handlers;

public class SearchPackingListsHandler : IQueryHandler<SearchPackingLists, IEnumerable<PackingListDto>>
{
    public async Task<IEnumerable<PackingListDto>> HandleAsync(SearchPackingLists query)
    {

    }
}
