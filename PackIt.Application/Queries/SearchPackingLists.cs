namespace PackIt.Application.Queries;

public class SearchPackingLists : IQuery<IEnumerable<PackingListDto>>
{
    public string Search { get; set; }
}
