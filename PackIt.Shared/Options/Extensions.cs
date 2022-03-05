using Microsoft.Extensions.Configuration;

namespace PackIt.Shared.Options;

public static class Extensions
{
    public static TOptions GetOptions<TOptions>(this IConfiguration @this, string sectionName) where TOptions : new()
    {
        var options = new TOptions();
        @this.GetSection(sectionName).Bind(options);
        return options;
    }
}
