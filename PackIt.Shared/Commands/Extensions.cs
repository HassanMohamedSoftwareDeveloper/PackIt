using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using PackIt.Shared.Abstractions.Commands;

namespace PackIt.Shared.Commands;

public static class Extensions
{
    public static IServiceCollection AddCommands(this IServiceCollection @this)
    {
        var assembly = Assembly.GetCallingAssembly();
        @this.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();
        @this.Scan(s => s.FromAssemblies(assembly)
        .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
        .AsImplementedInterfaces()
        .WithScopedLifetime());


        return @this;
    }
}
