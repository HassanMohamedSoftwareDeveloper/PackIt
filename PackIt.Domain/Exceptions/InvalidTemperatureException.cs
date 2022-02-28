namespace PackIt.Domain.Exceptions;

public class InvalidTemperatureException : PackItException
{
    public InvalidTemperatureException(double value)
        : base($"Value '{value}' is invalid temprature.") =>
        Value = value;

    public double Value { get; }
}
