using Microsoft.Extensions.DependencyInjection;


namespace PackIt.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection @this)
        {
            @this.AddCommands();
            @this.AddQueries();
            @this.AddSingleton<IPackingListFactory, PackingListFactory>();
            @this.Scan(b => b.FromAssemblies(typeof(IPackingItemsPolicy).Assembly)
            .AddClasses(c => c.AssignableTo<IPackingItemsPolicy>())
            .AsImplementedInterfaces()
            .WithSingletonLifetime());

            return @this;
        }
    }
}
