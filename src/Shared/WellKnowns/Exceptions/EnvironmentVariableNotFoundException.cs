namespace WellKnowns.Exceptions;

public sealed class EnvironmentVariableNotFoundException : Exception
{
    private static string MessageBuilder(string environmentVariableName) =>
        $"Environmement variable '{environmentVariableName}' not found.";

    public EnvironmentVariableNotFoundException(string environmentVariableName)
        : base(MessageBuilder(environmentVariableName)) { }

    public EnvironmentVariableNotFoundException(
        string environmentVariableName,
        Exception innerException
    )
        : base(MessageBuilder(environmentVariableName), innerException) { }

    private EnvironmentVariableNotFoundException() { }
}
