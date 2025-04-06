using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ollamish.WebApi.Endpoints.Chats.GetChat;

public class GetChatEndpoint : IGetChatEndpoint
{
    public void Map(IEndpointRouteBuilder endpointBuilder)
    {
        endpointBuilder.MapGet("/", HandleAsync).WithSummary($"Get Chat.").WithName("GetChat");
    }

    public Task<Ok<string>> HandleAsync(
        [FromQuery] string prompt,
        CancellationToken cancellationToken
    )
    {
        var response = prompt;
        return Task.FromResult(TypedResults.Ok(response));
    }
}
