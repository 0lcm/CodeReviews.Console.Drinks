namespace drinksInfo._0lcm.Models;

public static class ApiConstants
{
    public const string ApiName = "thecocktaildb.com";
    public const string ApiBaseUrl = "https://www.thecocktaildb.com/api/json/v1/1/";

    public const string LookupRandomCocktailPath = "random.php";

    public const string IncompleteLookupCocktailByNamePath = "search.php?s=";
    public const string IncompleteLookupIngredientByNamePath = "search.php?i=";
    public const string IncompleteLookupCocktailByIdPath = "lookup.php?i=";
    public const string IncompleteLookupIngredientByIdPath = "lookup.php?iid=";

    public const string IncompleteAlcoholContentFilterPath = "filter.php?a=";
    public const string IncompleteCategoryFilterPath = "filter.php?c=";
    public const string IncompleteGlassFilterPath = "filter.php?g=";
    public const string IncompleteIngredientFilterPath = "filter.php?i=";

    public const string DrinkCategoriesPath = "list.php?c=list";
    public const string GlassCategoriesPath = "list.php?g=list";
    public const string IngredientCategoriesPath = "list.php?i=list";
    public const string AlcoholContentCategoryPath = "list.php?a=list";
}