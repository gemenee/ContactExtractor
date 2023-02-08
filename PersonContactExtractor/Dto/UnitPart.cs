using System.Text.Json.Serialization;

namespace WebApplication.Dto;

public class UnitPart
{
    [JsonPropertyName("modifier")]
    public ModifierDto Modifier { get; set; }
    [JsonPropertyName("subdiv_type")]
    public string Subdivision { get; set; }
}