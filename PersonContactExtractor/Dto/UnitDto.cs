using System.Text;
using System.Text.Json.Serialization;

namespace PersonContactExtractor.Persistance;

public class UnitDto
{
    [JsonPropertyName("parts")]
    public UnintPart[] Parts { get; set; }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        foreach (var part in Parts)
        {
            if (part.Modifier is not null)
                result.Append(part.Modifier.Value ?? "");
            result.Append(' ');
            if (part.Subdivision is not null)
                result.Append(part.Subdivision ?? "");
            result.Append(" ");
        }

        return result.ToString().TrimEnd();
    }
}