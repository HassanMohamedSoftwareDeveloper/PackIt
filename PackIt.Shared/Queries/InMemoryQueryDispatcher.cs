using Microsoft.Extensions.DependencyInjection;
using PackIt.Shared.Abstractions.Queries;

namespace PackIt.Shared.Queries;

internal class InMemoryQueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public InMemoryQueryDispatcher(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public async Task<TResult?> QueryAsync<TResult>(IQuery<TResult> query)
    {
        using var scope = _serviceProvider.CreateScope();
        var handleType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
        var handler = scope.ServiceProvider.GetRequiredService(handleType);
        Task<TResult>? result = (Task<TResult>?)handleType
            .GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync))?
            .Invoke(handler, new[] { query });
        return result is null ? default : await result;
    }
}
