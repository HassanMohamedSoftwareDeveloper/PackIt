namespace PackIt.Domain.Events;

public record PackingItemRemoved(PackingList PackingList, PackingItem PackingItem) : IDomainEvent;
