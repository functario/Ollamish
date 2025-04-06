using Microsoft.Extensions.Hosting;
using Ollamish.App;

namespace Ollamish.Workbench;

internal static class Startup
{
    public static IHostBuilder CreateHostBuilder()
    {
        // csharpier-ignore-start
        var hostBuilder = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration(
                (_, configuration) =>
                {
                    configuration.Sources.Clear();
                }
            )
            .ConfigureServices(
            (context, services) =>
                services.AddOllamishApp(context)
            );

        // csharpier-ignore-ending
        return hostBuilder;
    }
}
