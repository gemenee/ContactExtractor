using System.Text.Json.Serialization;

namespace PersonContactExtractor.Persistance;

public class ContactsDto
{
    [JsonPropertyName("phone")]
    public string Phone { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; } 
}