using System.Text.Json.Serialization;

namespace PersonContactExtractor.Persistance;

public class NameDto
{
    [JsonPropertyName("first")]
    public string First { get; set; }
    [JsonPropertyName("last")]
    public string Last { get; set; }
    [JsonPropertyName("middle")]
    public string Middle { get; set; }
}