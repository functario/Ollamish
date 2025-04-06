using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Ollamish.App.Abstrations.UseCases.ChatSessions;
using Ollamish.EndpointMapper.Abstractions;

namespace Ollamish.WebApi.Endpoints.Chats.GetChat;

public interface IGetChatEndpoint : IGroupedEndpoint<ChatSessionGroup>
{
    Task<Ok<string>> HandleAsync(
        [FromQuery] string prompt,
        [FromServices] IChatSession chatSession,
        CancellationToken cancellationToken
    );
}
