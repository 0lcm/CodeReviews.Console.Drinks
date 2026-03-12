using System.Text.Json.Serialization;

namespace drinksInfo._0lcm.Models;

public class LookupIngredientClassResponse
{
    [JsonPropertyName("ingredients")] public required List<LookupIngredientClass> Ingredients { get; set; }
}

public class LookupIngredientClass
{
    [JsonPropertyName("strIngredient")] public string? StrIngredient { get; set; }
    [JsonPropertyName("idIngredient")] public string? IdIngredient { get; set; }
    [JsonPropertyName("strDescription")] public string? StrDescription { get; set; }
    [JsonPropertyName("strType")] public string? StrType { get; set; }
    [JsonPropertyName("strAlcohol")] public string? StrAlcohol { get; set; }
    [JsonPropertyName("strABV")] public string? StrAbv { get; set; }

    [JsonIgnore]
    public List<(string Field, string Value)> IngredientInfo =>
        new List<(string, string?)>
            {
                ("Ingredient Name", StrIngredient),
                ("Ingredient Id", IdIngredient),
                ("Ingredient Description", StrDescription),
                ("Ingredient Type", StrType),
                ("Ingredient Alcohol", StrAlcohol),
                ("Ingredient Abv", StrAbv)
            }
            .Where(x => !string.IsNullOrEmpty(x.Item2) && x.Item2 != "null")
            .Select(x => (x.Item1, x.Item2!))
            .ToList();
}