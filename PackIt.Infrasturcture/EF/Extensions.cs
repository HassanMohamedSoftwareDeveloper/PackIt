using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIt.Application.Services;
using PackIt.Infrasturcture.EF.Contexts;
using PackIt.Infrasturcture.EF.Options;
using PackIt.Infrasturcture.EF.Repositories;
using PackIt.Infrasturcture.EF.Services;
using PackIt.Shared.Options;

namespace PackIt.Infrasturcture.EF;

internal static class Extensions
{
    public static IServiceCollection AddPostgres(this IServiceCollection @this, IConfiguration configuration)
    {
        @this.AddScoped<IPackingListRepository, PostgresPackingListRepository>();
        @this.AddScoped<IPackingListReadService, PostgresPackingListReadService>();

        var options = configuration.GetOptions<PostgresOptions>("Postgres");

        @this.AddDbContext<ReadDbContext>(ctx => ctx.UseNpgsql(options.ConnectionString));
        @this.AddDbContext<WriteDbContext>(ctx => ctx.UseNpgsql(options.ConnectionString));

        return @this;
    }
}
