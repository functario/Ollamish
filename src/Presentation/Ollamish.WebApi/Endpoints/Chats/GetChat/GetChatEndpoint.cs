using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Ollamish.App.Abstrations.UseCases.ChatSessions;

namespace Ollamish.WebApi.Endpoints.Chats.GetChat;

public class GetChatEndpoint : IGetChatEndpoint
{
    public void Map(IEndpointRouteBuilder endpointBuilder)
    {
        endpointBuilder.MapGet("/", HandleAsync).WithSummary($"Get Chat.").WithName("GetChat");
    }

    public async Task<Ok<string>> HandleAsync(
        [FromQuery] string prompt,
        [FromServices] IChatSession chatSession,
        CancellationToken cancellationToken
    )
    {
        ArgumentNullException.ThrowIfNull(chatSession, nameof(chatSession));
        var response = await chatSession.Ask(prompt, cancellationToken);
        return TypedResults.Ok(response);
    }
}
