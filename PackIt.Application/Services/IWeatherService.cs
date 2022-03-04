namespace PackIt.Application.Services;

public interface IWeatherService
{
    Task<WeatherDto> GetWeatherAsync(Localization localization);
}
