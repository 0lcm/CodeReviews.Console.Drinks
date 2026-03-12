using System.Text.Json.Serialization;

namespace drinksInfo._0lcm.Models;

public class LookupDrinkClassResponse
{
    [JsonPropertyName("drinks")] public required List<LookupDrinkClass> Drinks { get; set; }
}

public class LookupDrinkClass
{
    [JsonPropertyName("idDrink")] public string? IdDrink { get; set; }
    [JsonPropertyName("strDrink")] public string? StrDrink { get; set; }

    [JsonPropertyName("strDrinkAlternate")]
    public string? StrDrinkAlternate { get; set; }

    [JsonPropertyName("strTags")] public string? StrTags { get; set; }
    [JsonPropertyName("strVideo")] public string? StrVideo { get; set; }
    [JsonPropertyName("strCategory")] public string? StrCategory { get; set; }
    [JsonPropertyName("strIBA")] public string? StrIba { get; set; }
    [JsonPropertyName("strAlcoholic")] public string? StrAlcoholic { get; set; }
    [JsonPropertyName("strGlass")] public string? StrGlass { get; set; }
    [JsonPropertyName("strInstructions")] public string? StrInstructions { get; set; }

    [JsonPropertyName("strDrinkThumb")] public string? StrDrinkThumb { get; set; }
    [JsonPropertyName("strImageSource")] public string? StrImageSource { get; set; }

    [JsonPropertyName("strImageAttribution")]
    public string? StrImageAttribution { get; set; }

    [JsonPropertyName("strCreativeCommonsConfirmed")]
    public string? StrCreativeCommonsConfirmed { get; set; }

    [JsonPropertyName("dataModified")] public string? DateModified { get; set; }

    [JsonPropertyName("strIngredient1")] public string? StrIngredient1 { get; set; }
    [JsonPropertyName("strIngredient2")] public string? StrIngredient2 { get; set; }
    [JsonPropertyName("strIngredient3")] public string? StrIngredient3 { get; set; }
    [JsonPropertyName("strIngredient4")] public string? StrIngredient4 { get; set; }
    [JsonPropertyName("strIngredient5")] public string? StrIngredient5 { get; set; }
    [JsonPropertyName("strIngredient6")] public string? StrIngredient6 { get; set; }
    [JsonPropertyName("strIngredient7")] public string? StrIngredient7 { get; set; }
    [JsonPropertyName("strIngredient8")] public string? StrIngredient8 { get; set; }
    [JsonPropertyName("strIngredient9")] public string? StrIngredient9 { get; set; }
    [JsonPropertyName("strIngredient10")] public string? StrIngredient10 { get; set; }
    [JsonPropertyName("strIngredient11")] public string? StrIngredient11 { get; set; }
    [JsonPropertyName("strIngredient12")] public string? StrIngredient12 { get; set; }
    [JsonPropertyName("strIngredient13")] public string? StrIngredient13 { get; set; }
    [JsonPropertyName("strIngredient14")] public string? StrIngredient14 { get; set; }
    [JsonPropertyName("strIngredient15")] public string? StrIngredient15 { get; set; }

    [JsonPropertyName("strMeasure1")] public string? StrMeasure1 { get; set; }
    [JsonPropertyName("strMeasure2")] public string? StrMeasure2 { get; set; }
    [JsonPropertyName("strMeasure3")] public string? StrMeasure3 { get; set; }
    [JsonPropertyName("strMeasure4")] public string? StrMeasure4 { get; set; }
    [JsonPropertyName("strMeasure5")] public string? StrMeasure5 { get; set; }
    [JsonPropertyName("strMeasure6")] public string? StrMeasure6 { get; set; }
    [JsonPropertyName("strMeasure7")] public string? StrMeasure7 { get; set; }
    [JsonPropertyName("strMeasure8")] public string? StrMeasure8 { get; set; }
    [JsonPropertyName("strMeasure9")] public string? StrMeasure9 { get; set; }
    [JsonPropertyName("strMeasure10")] public string? StrMeasure10 { get; set; }
    [JsonPropertyName("strMeasure11")] public string? StrMeasure11 { get; set; }
    [JsonPropertyName("strMeasure12")] public string? StrMeasure12 { get; set; }
    [JsonPropertyName("strMeasure13")] public string? StrMeasure13 { get; set; }
    [JsonPropertyName("strMeasure14")] public string? StrMeasure14 { get; set; }
    [JsonPropertyName("strMeasure15")] public string? StrMeasure15 { get; set; }

    [JsonIgnore]
    public List<(string Ingredient, string Measure)> Ingredients =>
        new List<(string?, string?)>
            {
                (StrIngredient1, StrMeasure1),
                (StrIngredient2, StrMeasure2),
                (StrIngredient3, StrMeasure3),
                (StrIngredient4, StrMeasure4),
                (StrIngredient5, StrMeasure5),
                (StrIngredient6, StrMeasure6),
                (StrIngredient7, StrMeasure7),
                (StrIngredient8, StrMeasure8),
                (StrIngredient9, StrMeasure9),
                (StrIngredient10, StrMeasure10),
                (StrIngredient11, StrMeasure11),
                (StrIngredient12, StrMeasure12),
                (StrIngredient13, StrMeasure13),
                (StrIngredient14, StrMeasure14),
                (StrIngredient15, StrMeasure15)
            }
            .Where(x => !string.IsNullOrEmpty(x.Item1) && x.Item1 != "null")
            .Select(x => (x.Item1!, x.Item2 ?? string.Empty))
            .ToList();

    [JsonIgnore]
    public List<(string Field, string Value)> DrinkInfo =>
        new List<(string, string?)>
            {
                ("Name", StrDrink),
                ("Alternate Name", StrDrinkAlternate),
                ("Drink Id", IdDrink),
                ("Drink Category", StrCategory),
                ("Alcohol Content", StrAlcoholic),
                ("Drink Glass", StrGlass),
                ("Drink Tags", StrTags),
                ("Drink IBA", StrIba),
                ("Drink Video", StrVideo),
                ("Instructions", StrInstructions)
            }
            .Where(x => !string.IsNullOrEmpty(x.Item2) && x.Item2 != "null")
            .Select(x => (x.Item1, x.Item2!))
            .ToList();

    [JsonIgnore]
    public List<(string Field, string Value)> DrinkPhotoInfo =>
        new List<(string, string?)>
            {
                ("Image Source", StrImageSource),
                ("Image Attribution", StrImageAttribution),
                ("Creative Commons Confirmed", StrCreativeCommonsConfirmed),
                ("Date modified", DateModified)
            }
            .Where(x => !string.IsNullOrEmpty(x.Item2) && x.Item2 != "null")
            .Select(x => (x.Item1, x.Item2!))
            .ToList();
}