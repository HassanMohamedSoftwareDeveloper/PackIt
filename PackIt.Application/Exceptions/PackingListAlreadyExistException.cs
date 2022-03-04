namespace PackIt.Application.Exceptions;

public class PackingListAlreadyExistException : PackItException
{
    public PackingListAlreadyExistException(string name)
        : base($"Packing list with name '{name}' already exist.") => Name = name;

    public string Name { get; }
}
