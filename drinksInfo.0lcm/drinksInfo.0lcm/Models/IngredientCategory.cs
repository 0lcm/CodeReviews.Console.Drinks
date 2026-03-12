using System.Text.Json.Serialization;

namespace drinksInfo._0lcm.Models;

public class IngredientCategoryResponse
{
    [JsonPropertyName("drinks")] public required List<IngredientCategory> IngredientCategory { get; set; }
}

public class IngredientCategory
{
    [JsonPropertyName("strIngredient1")] public required string StrIngredient { get; set; }
}