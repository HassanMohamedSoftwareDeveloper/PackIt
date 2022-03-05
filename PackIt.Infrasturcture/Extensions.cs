using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIt.Application.Services;
using PackIt.Infrasturcture.EF;
using PackIt.Infrasturcture.Logging;
using PackIt.Infrasturcture.Services;
using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Infrasturcture
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrasturcture(this IServiceCollection @this, IConfiguration configuration)
        {
            @this.AddPostgres(configuration);
            @this.AddQueries();
            @this.AddSingleton<IWeatherService, DumbWeatherService>();
            @this.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));
            return @this;
        }
    }
}
