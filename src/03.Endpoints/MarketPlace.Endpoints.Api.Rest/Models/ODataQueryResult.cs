using System.Text.Json.Serialization;

namespace MarketPlace.Endpoints.Api.Rest.Models;

public class ODataQueryResult<T>
{
    [JsonPropertyName("@odata.count")] public long Count { get; set; }
    [JsonPropertyName("@odata.nextLink")] public required string NextLink { get; set; }
    public required IEnumerable<T> Value { get; set; }
}