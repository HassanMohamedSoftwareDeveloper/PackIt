using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIt.Application.Services;
using PackIt.Infrasturcture.EF;
using PackIt.Infrasturcture.Services;

namespace PackIt.Infrasturcture
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrasturcture(this IServiceCollection @this, IConfiguration configuration)
        {
            @this.AddPostgres(configuration);
            @this.AddQueries();
            @this.AddSingleton<IWeatherService, DumbWeatherService>();
            return @this;
        }
    }
}
