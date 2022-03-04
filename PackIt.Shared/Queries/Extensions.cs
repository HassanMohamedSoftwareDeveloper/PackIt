using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using PackIt.Shared.Abstractions.Queries;

namespace PackIt.Shared.Queries;

public static class Extensions
{
    public static IServiceCollection AddQueries(this IServiceCollection @this)
    {
        var assembly = Assembly.GetCallingAssembly();
        @this.AddSingleton<IQueryDispatcher, InMemoryQueryDispatcher>();
        @this.Scan(s => s.FromAssemblies(assembly)
        .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
        .AsImplementedInterfaces()
        .WithScopedLifetime());


        return @this;
    }
}
