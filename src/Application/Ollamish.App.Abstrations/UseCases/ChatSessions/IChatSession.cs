namespace Ollamish.App.Abstrations.UseCases.ChatSessions;

public interface IChatSession
{
    public Task<string> Ask(string prompt, CancellationToken cancellationToken);
}
