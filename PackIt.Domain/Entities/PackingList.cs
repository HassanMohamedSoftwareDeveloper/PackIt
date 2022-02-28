namespace PackIt.Domain.Entities;

public class PackingList
{
    public Guid Id { get; private set; }

    private PackingListName _name;
    private Localization _localization;

    private readonly LinkedList<PackingItem> _items = new();

    internal PackingList(Guid id, PackingListName name, Localization localization, LinkedList<PackingItem> items)
    {
        Id = id;
        _name = name;
        _localization = localization;
    }

    public void AddItem(PackingItem item)
    {
        var alreadyExist = _items.Any(x => x.Name.Equals(item.Name));
        if (alreadyExist) throw new PackingItemAlreadyExistException(_name, item.Name);
        _items.AddLast(item);
    }
}
