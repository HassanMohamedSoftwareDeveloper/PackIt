namespace PackIt.Application.Queries;

public class SearchPackingLists : IQuery<IEnumerable<PackingListDto>>
{
    public string SearchPhrase { get; set; }
}
