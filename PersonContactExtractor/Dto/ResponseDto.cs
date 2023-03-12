using System.Text.Json.Serialization;
using WebApplication.Dto;

namespace WebApplication.Dto;


public class ResponseDto
{
    [JsonPropertyName("contacts")]
    public ContactsDto Contacts { get; set; }

    [JsonPropertyName("birthDate")]
    public BirthDateDto BirthDate { get; set; }

    [JsonPropertyName("name")]
    public NameDto NameDto { get; set; }

    [JsonPropertyName("organization")]
    public OrganizationDto Organization { get; set; }

    [JsonPropertyName("position")]
    public PositionDto Position { get; set; }
}

/*
  {
    "contacts": {
      "phone": "(89876543210)"
    },
    "name": {
      "first": "\u041e",
      "last": "\u0417\u043b\u044b\u0431\u0438\u043d",
      "middle": "\u041f"
    },
    "organization": {
      "org_name": "\u043f\u043e\u043b\u0438\u0446\u0438\u044f",
      "unit": {
        "parts": [
          {
            "modifier": {
              "value": "3"
            },
            "subdiv_type": "\u043e\u0442\u0434\u0435\u043b"
          }
        ]
      }
    },
    "position": {
      "prefix": "\u041e\u043f\u0435\u0440\u0430\u0442\u0438\u0432\u043d\u044b\u0439",
      "value": "\u0441\u043e\u0442\u0440\u0443\u0434\u043d\u0438\u043a"
    }
  }
*/