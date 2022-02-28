namespace PackIt.Domain.Events;

public record PackingItemPacked(PackingList PackingList, PackingItem PackingItem) : IDomainEvent;
