using System.Text.Json.Serialization;

namespace PersonContactExtractor.Persistance;

public class PositionDto
{
    [JsonPropertyName("prefix")]
    public string Prefix { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }

    public override string ToString()
    {
        return this.Prefix + " " + this.Value;
    }
}