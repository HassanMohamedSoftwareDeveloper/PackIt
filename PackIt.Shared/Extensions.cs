using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PackIt.Shared.Exceptions;
using PackIt.Shared.Services;

namespace PackIt.Shared;

public static class Extensions
{
    public static IServiceCollection AddShared(this IServiceCollection @this)
    {
        @this.AddHostedService<AppInitializer>();
        @this.AddScoped<ExceptionMiddleWare>();
        return @this;
    }
    public static IApplicationBuilder UseShared(this IApplicationBuilder @this)
    {
        @this.UseMiddleware<ExceptionMiddleWare>();
        return @this;
    }
}
