namespace drinksInfo._0lcm.Enums;

internal static class Enums
{
    internal enum MainMenuOption
    {
        LookupBySpecifics,
        FilterByCategories,
        ReviewCategories,
        SeeFavoritesAndViewCounts,
        Settings,
        Exit
    }

    internal enum ReviewCategoriesOption
    {
        SeeDrinks,
        SeeGlasses,
        SeeIngredients,
        SeeAlcoholicTypes,
        Back
    }

    internal enum FilterCategoriesOption
    {
        FilterByAlcoholContent,
        FilterByDrinkCategory,
        FilterByIngredient,
        FilterByGlassType,
        Back
    }

    internal enum LookupSpecificsOption
    {
        LookupCocktailByName,
        LookupIngredientByName,
        LookupCocktailById,
        LookupIngredientById,
        LookupRandomCocktail,
        Back
    }

    internal enum SettingsMenuOption
    {
        ToggleShowImages,
        ChangeImageMaxWidth,
        ToggleStoreViewCounts,
        ChangeMaxLeaderboardSpots,
        ResetSettings,
        Back
    }

    internal enum FavoritesAndLeaderboardMenuOption
    {
        ShowFavorites,
        ShowViewLeaderboard,
        Back
    }
}