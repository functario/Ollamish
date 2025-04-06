using Ollamish.EndpointMapper.Abstractions;

namespace Ollamish.WebApi.Endpoints.Chats;

public sealed class ChatSessionGroup : IGroup
{
    public ChatSessionGroup(IEndpointRouteBuilder routeGroupBuilder)
    {
        Builder = routeGroupBuilder.MapGroup("v1/chat").WithOpenApi().WithTags("Chat");
    }

    public IEndpointRouteBuilder Builder { get; }
}
