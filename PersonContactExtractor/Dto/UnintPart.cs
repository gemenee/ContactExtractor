using System.Text.Json.Serialization;

namespace PersonContactExtractor.Persistance;

public class UnintPart
{
    [JsonPropertyName("modifier")]
    public ModifierDto Modifier { get; set; }
    [JsonPropertyName("subdiv_type")]
    public string Subdivision { get; set; }
}