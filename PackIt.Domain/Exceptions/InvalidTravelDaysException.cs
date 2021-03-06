namespace PackIt.Domain.Exceptions;

public class InvalidTravelDaysException : PackItException
{
    public InvalidTravelDaysException(ushort days)
        : base($"Value '{days}' is invalid travel days.") => Days = days;

    public ushort Days { get; }
}
