using Microsoft.AspNetCore.Routing;

namespace Ollamish.EndpointMapper.Abstractions;

[System.Diagnostics.CodeAnalysis.SuppressMessage(
    "Maintainability",
    "CA1515:Consider making public types internal",
    Justification = "<Pending>"
)]
public interface IGroup
{
    public IEndpointRouteBuilder Builder { get; }
}
