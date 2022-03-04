namespace PackIt.Application.Exceptions;

public class PackingListNotFoundException : PackItException
{
    public PackingListNotFoundException(Guid id)
        : base($"Packing list with id '{id}' not found") => Id = id;

    public Guid Id { get; }
}
