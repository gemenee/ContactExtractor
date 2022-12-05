using System.Text.Json.Serialization;

namespace PersonContactExtractor.Persistance;

public class PositionDto
{
    [JsonPropertyName("prefix")]
    public string Prefix { get; set; }
    [JsonPropertyName("value")]
    public string Value { get; set; }
}