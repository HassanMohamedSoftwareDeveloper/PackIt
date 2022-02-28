namespace PackIt.Domain.Events;

public record PackingItemAdded(PackingList PackingList, PackingItem PackingItem)
    : IDomainEvent;
