using System.Text;
using Microsoft.KernelMemory;
using Microsoft.KernelMemory.AI.Ollama;
using Ollamish.App.Abstrations.UseCases.ChatSessions;

namespace Ollamish.App.UseCases.ChatSessions;

internal class ChatSession : IChatSession
{
    private readonly OllamaConfig _ollamaConfig;

    public ChatSession(OllamaConfig ollamaConfig)
    {
        _ollamaConfig = ollamaConfig;
    }

    public async Task<string> Ask(string prompt, CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(prompt, nameof(prompt));
        var memory = new KernelMemoryBuilder()
            .WithOllamaTextGeneration(_ollamaConfig)
            .WithOllamaTextEmbeddingGeneration(_ollamaConfig)
            .Build<MemoryServerless>();

        var documentId = "DOC0001";
        var docName = $"Documents/{documentId}.txt";

        await memory.ImportDocumentAsync(
            docName,
            documentId: documentId,
            cancellationToken: cancellationToken
        );

        // Could lock if cancellationToken is infinite.
        await memory.IsDocumentReadyAsync(documentId, cancellationToken: cancellationToken);

        var answer = await memory.AskAsync(prompt, cancellationToken: cancellationToken);

        var str = new StringBuilder(answer.Result);

        foreach (var x in answer.RelevantSources)
        {
            var source = $"{x.SourceName} - {x.SourceUrl} - {x.Link}";
            str.AppendLine(source);
        }

        return str.ToString();
    }
}
