namespace PackIt.Application.Queries;

public class GetPackingList : IQuery<PackingListDto>
{
    public Guid Id { get; set; }
}
