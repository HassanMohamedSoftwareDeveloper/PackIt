using Microsoft.Extensions.DependencyInjection;
using PackIt.Shared.Services;

namespace PackIt.Shared;

public static class Extensions
{
    public static IServiceCollection AddShared(this IServiceCollection @this)
    {
        @this.AddHostedService<AppInitializer>();
        return @this;
    }
}
