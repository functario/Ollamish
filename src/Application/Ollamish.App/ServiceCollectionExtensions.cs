using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.KernelMemory.AI.Ollama;
using Ollamish.App.Abstrations.UseCases.ChatSessions;
using Ollamish.App.UseCases.ChatSessions;
using WellKnowns.Aspire;
using WellKnowns.Exceptions;
using WellKnowns.Presentation;

namespace Ollamish.App;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOllamishApp(
        this IServiceCollection services,
        HostBuilderContext _
    )
    {
        return BuildType.IsOpenApiGeneratorBuild()
            ? services
            : services.AddScoped<IChatSession, ChatSession>().AddOllama();
    }

    internal static IServiceCollection AddOllama(this IServiceCollection services)
    {
        var connectionStringVarName =
            Environment.GetEnvironmentVariable(OllamaEnvironmentVariables.OllamaConnectionstrings)
            ?? throw new EnvironmentVariableNotFoundException(
                OllamaEnvironmentVariables.OllamaConnectionstrings
            );

        var endpoint =
            Environment.GetEnvironmentVariable(connectionStringVarName)
            ?? throw new EnvironmentVariableNotFoundException(connectionStringVarName);

        var textModel =
            Environment.GetEnvironmentVariable(OllamaEnvironmentVariables.OllamaTextModel)
            ?? throw new EnvironmentVariableNotFoundException(
                OllamaEnvironmentVariables.OllamaTextModel
            );

        var embeddingModel =
            Environment.GetEnvironmentVariable(OllamaEnvironmentVariables.OllamaEmbeddingModel)
            ?? throw new EnvironmentVariableNotFoundException(
                OllamaEnvironmentVariables.OllamaEmbeddingModel
            );

        services.AddScoped(x =>
        {
            return new OllamaConfig
            {
                Endpoint = endpoint.Replace(
                    "endpoint=",
                    "",
                    StringComparison.InvariantCultureIgnoreCase
                ),
                TextModel = new OllamaModelConfig(textModel, 131072),
                EmbeddingModel = new OllamaModelConfig(embeddingModel, 2048),
            };
        });

        return services;
    }
}
