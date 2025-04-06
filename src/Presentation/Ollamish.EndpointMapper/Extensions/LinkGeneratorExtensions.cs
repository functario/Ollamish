using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Ollamish.EndpointMapper.Extensions;

internal static class LinkGeneratorExtensions
{
    public static Uri GetLocationUri(
        this LinkGenerator linkGenerator,
        HttpContext httpContext,
        string getEndpointName,
        object values
    )
    {
        var link = linkGenerator.GetUriByName(httpContext, getEndpointName, values)!;

        return link is null
            ? throw new InvalidOperationException(
                $"Could not generate uri from endpoint named '{getEndpointName}' with values {string.Join(';', values)}"
            )
            : new Uri(link);
    }
}
