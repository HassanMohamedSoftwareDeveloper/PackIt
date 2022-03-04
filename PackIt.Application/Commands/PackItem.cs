namespace PackIt.Application.Commands;

public record PackItem(Guid PackingListId, string Name) : ICommand;
