using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Ollamish.App;
using Ollamish.EndpointMapper.Extensions;
using WellKnowns.Exceptions;
using WellKnowns.Presentation;

namespace Ollamish.WebApi;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOllamishWebApi(
        this IServiceCollection services,
        HostBuilderContext context
    )
    {
        services
            .AddOllamishApp(context)
            .AddEndpoints(Assembly.GetAssembly(typeof(Program))!)
            .AddEndpointsApiExplorer()
            .WithTimeProvider()
            .WithOpenApi();

        return services;
    }

    internal static IServiceCollection WithTimeProvider(this IServiceCollection services)
    {
        services.TryAddSingleton<TimeProvider>(x => TimeProvider.System);
        return services;
    }

    internal static IServiceCollection WithOpenApi(this IServiceCollection services)
    {
        return services.AddOpenApi(x =>
        {
            var openApiDeaultUrl =
                Environment.GetEnvironmentVariable(WebApiEnvironmentVariables.OpenApiDefaultUrl)
                ?? throw new EnvironmentVariableNotFoundException(
                    WebApiEnvironmentVariables.OpenApiDefaultUrl
                );

            x.AddDocumentTransformer(
                (document, context, cancellationToken) =>
                {
                    // Configure default url to display inside OpenAPI contract
                    document.Servers.Add(
                        new Microsoft.OpenApi.Models.OpenApiServer() { Url = openApiDeaultUrl }
                    );

                    return Task.CompletedTask;
                }
            );
        });
    }
}
