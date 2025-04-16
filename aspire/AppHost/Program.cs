using WellKnowns.Aspire;
using WellKnowns.Presentation;

var builder = DistributedApplication.CreateBuilder(args);

var ollama = builder
    .AddOllama(OllamaProjectReferences.ProjectName)
    .WithGPUSupport()
    .WithDataVolume()
    .WithExternalHttpEndpoints()
    .WithOpenWebUI(x => x.WithLifetime(ContainerLifetime.Persistent))
    .WithLifetime(ContainerLifetime.Persistent);

ollama.AddModel("llama3:8b");
//ollama.AddModel("deepseek-r1:8b");
//ollama.AddModel("stablelm2:12b");
//ollama.AddModel("phi4");

builder
    .AddProject<Projects.Ollamish_WebApi>(WebApiProjectReferences.ProjectName)
    .WithEndpoint("https", endpoint => endpoint.IsProxied = false)
    .WithEndpoint("http", endpoint => endpoint.IsProxied = false)
    .WaitFor(ollama)
    .WithReference(ollama);

builder.Build().Run();
