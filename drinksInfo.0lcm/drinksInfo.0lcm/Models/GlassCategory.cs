using System.Text.Json.Serialization;

namespace drinksInfo._0lcm.Models;

public class GlassCategoryResponse
{
    [JsonPropertyName("drinks")] public required List<GlassCategory> GlassCategory { get; set; }
}

public class GlassCategory
{
    [JsonPropertyName("strGlass")] public required string StrGlass { get; set; }
}