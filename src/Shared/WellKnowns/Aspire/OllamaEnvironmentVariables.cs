namespace WellKnowns.Aspire;

public static class OllamaEnvironmentVariables
{
    public const string OllamaConnectionstrings =
        $"{EnvironmentVariables.Prefix}_OLLAMA_CONNECTIONSTRINGS";

    public const string OllamaTextModel = $"{EnvironmentVariables.Prefix}_OLLAMA_TEXTMODEL";

    public const string OllamaEmbeddingModel =
        $"{EnvironmentVariables.Prefix}_OLLAMA_EMBEDDINGMODEL";
}
