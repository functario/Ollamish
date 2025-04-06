using System.Collections.Frozen;

namespace Ollamish.EndpointMapper.Models;

internal sealed record GroupedEndpoints(Dictionary<Type, FrozenSet<Type>> KeyValuePairs) { }
