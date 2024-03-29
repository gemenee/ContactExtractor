﻿using System.Text.Json.Serialization;

namespace PersonContactExtractor.Persistance;

public class OrganizationDto
{
    [JsonPropertyName("org_name")]
    public string OrgName { get; set; }

    [JsonPropertyName("unit")]
    public UnitDto UnitDto { get; set; }
}