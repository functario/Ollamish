var builder = DistributedApplication.CreateBuilder(args);

var ollamaServiceName = "ollama";
var ollama = builder
    .AddOllama(ollamaServiceName)
    .WithGPUSupport()
    .WithDataVolume()
    .WithExternalHttpEndpoints()
    .WithOpenWebUI(x => x.WithLifetime(ContainerLifetime.Persistent))
    .WithLifetime(ContainerLifetime.Persistent);

//var deepseek = ollama.AddModel("llama3:latest");

var deepseek = ollama.AddModel("llama2-uncensored:7b");

//var deepseek = ollama.AddModel("dolphin-mixtral:8x7b");
//ollama.AddModel("deepseek-r1:8b");
//ollama.AddModel("phi4");

// CLI

//builder.AddProject<Projects.Ollamish_Cli>("ollamish-cli")
//    .WithReference(deepseek)
//    .WaitFor(deepseek);


builder.Build().Run();
