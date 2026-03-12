using System.Text.Json.Serialization;

namespace drinksInfo._0lcm.Models;

public class FilterClassResponse
{
    [JsonPropertyName("drinks")] public required List<FilterClass> FilterElements { get; set; }
}

public class FilterClass
{
    [JsonPropertyName("strDrink")] public required string StrDrink { get; set; }
    [JsonPropertyName("strDrinkThumb")] public required string StrDrinkThumb { get; set; }
    [JsonPropertyName("idDrink")] public required string IdDrink { get; set; }
}