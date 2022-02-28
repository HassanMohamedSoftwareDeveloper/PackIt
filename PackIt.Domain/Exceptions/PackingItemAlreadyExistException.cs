namespace PackIt.Domain.Exceptions;

public class PackingItemAlreadyExistException : PackItException
{
    public PackingItemAlreadyExistException(string listName, string itemName)
        : base($"Packing list: '{listName}' already defined item: '{itemName}'.")
    {
        ListName = listName;
        ItemName = itemName;
    }

    public string ListName { get; }
    public string ItemName { get; }
}
