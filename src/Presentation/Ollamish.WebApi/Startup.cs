using dotenv.net;
using Ollamish.EndpointMapper.Extensions;
using ServiceDefaults;
using WellKnowns.Presentation;

namespace Ollamish.WebApi;

internal static class Startup
{
    public static async Task Start(string[] args)
    {
        DotEnv.Fluent().WithTrimValues().WithOverwriteExistingVars().Load();
        var builder = CreateWebHostBuilder(args);
        var app = BuildWebAppAsync(builder);
        await app.RunAsync();
    }

    internal static WebApplicationBuilder CreateWebHostBuilder(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddServiceDefaults();

        builder.Host.ConfigureServices((context, services) => services.AddOllamishWebApi(context));

        return builder;
    }

    internal static WebApplication BuildWebAppAsync(WebApplicationBuilder builder)
    {
        var app = builder.Build();

        app.MapGroupedEndpoints();

        if (app.Environment.IsDevelopment())
        {
            app.MapDefaultEndpoints();
            app.MapOpenApi();
            app.UseSwaggerUI(x =>
                x.SwaggerEndpoint(WebApiConstants.OpenApiContract, WebApiConstants.OpenApiVersion)
            );
        }

        app.UseHttpsRedirection();
        return app;
    }
}
