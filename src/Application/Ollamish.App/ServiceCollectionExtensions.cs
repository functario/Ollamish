using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ollamish.App;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOllamishApp(
        this IServiceCollection services,
        HostBuilderContext _
    )
    {
        return services;
    }
}
