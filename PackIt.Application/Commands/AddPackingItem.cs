﻿namespace PackIt.Application.Commands;

public record AddPackingItem(Guid PackingListId, string Name, uint Quantity) : ICommand;
