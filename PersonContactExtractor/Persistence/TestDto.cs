using System.Text.Json.Serialization;

namespace PersonContactExtractor.Persistance;

public class TestDto
{
    [JsonPropertyName("content")]
    public string Content { get; set; }
}