using System.Text.Json.Serialization;

namespace drinksInfo._0lcm.Models;

public class DrinkCategoryResponse
{
    [JsonPropertyName("drinks")] public required List<DrinkCategory> Drinks { get; set; }
}

public class DrinkCategory
{
    [JsonPropertyName("strCategory")] public required string StrCategory { get; set; }
}