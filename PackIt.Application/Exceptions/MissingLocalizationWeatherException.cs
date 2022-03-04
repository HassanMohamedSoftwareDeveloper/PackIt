namespace PackIt.Application.Exceptions;

public class MissingLocalizationWeatherException : PackItException
{
    public MissingLocalizationWeatherException(Localization localization)
        : base($"Couldn't featch weather data for localization '{localization.Country}/{localization.City}'.")
    => Localization = localization;

    public Localization Localization { get; }
}
