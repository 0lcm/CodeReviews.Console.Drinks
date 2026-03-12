using System.Text.Json.Serialization;

namespace drinksInfo._0lcm.Models;

public class AlcoholContentCategoryResponse
{
    [JsonPropertyName("drinks")] public required List<AlcoholContentCategory> AlcoholContentCategory { get; set; }
}

public class AlcoholContentCategory
{
    [JsonPropertyName("strAlcoholic")] public required string StrAlcoholic { get; set; }
}