using System.Text.Json.Serialization;

namespace PersonContactExtractor.Persistance;

public class UnitDto
{
    [JsonPropertyName("parts")]
    public UnintPart[] Parts { get; set; }
}