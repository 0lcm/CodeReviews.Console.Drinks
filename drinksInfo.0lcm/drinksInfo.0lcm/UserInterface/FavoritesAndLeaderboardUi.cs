using drinksInfo._0lcm.Configuration;
using drinksInfo._0lcm.Models;
using drinksInfo._0lcm.ServiceContracts;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace drinksInfo._0lcm.UserInterface;

public class FavoritesAndLeaderboardUi(IDrinkStateService drinkStateService, AppSettings appSettings)
{
    private const string White = DisplayHelper.White;
    private const string Green = DisplayHelper.Green;
    private const string Grey = DisplayHelper.Grey;
    private readonly IDrinkStateService _drinkStateService = drinkStateService;

    //------- Ui Methods -------
    internal async Task FavoritesAndLeaderboard()
    {
        var showFavorites = true;

        while (true)
        {
            Console.Clear();

            if (showFavorites)
            {
                DisplayHelper.DisplaySuccess("Favorites:");

                var favoritedDrinks = await _drinkStateService.GetFavorites();
                var iRenderables = BuildFavoritedDrinks(favoritedDrinks);

                DisplayHelper.DisplayRows(iRenderables);
            }
            else
            {
                DisplayHelper.DisplaySuccess("View Count Leaderboard:");
                var viewedDrinks = await _drinkStateService.GetViewedDrinks();
                var iRenderables = BuildViewedDrinks(viewedDrinks);

                DisplayHelper.DisplayRows(iRenderables);
            }

            var option =
                DisplayHelper.DisplayMenu<Enums.Enums.FavoritesAndLeaderboardMenuOption>("\nPlease Select an Option:");
            var shouldShowFavorites = HandleMenuOption(option);

            if (shouldShowFavorites == null) return;
            showFavorites = shouldShowFavorites is true;
        }
    }

    /// <summary>
    ///     handles the main menu's options
    /// </summary>
    /// <param name="option"></param>
    /// <returns>true if menu should show favorites, false if menu should show view count, and null if menu should return.</returns>
    private static bool? HandleMenuOption(Enums.Enums.FavoritesAndLeaderboardMenuOption option)
    {
        switch (option)
        {
            case Enums.Enums.FavoritesAndLeaderboardMenuOption.ShowFavorites:
                return true;
            case Enums.Enums.FavoritesAndLeaderboardMenuOption.ShowViewLeaderboard:
                return false;
            case Enums.Enums.FavoritesAndLeaderboardMenuOption.Back:
            default:
                return null;
        }
    }

    //------- Helper Methods -------
    private static List<IRenderable> BuildFavoritedDrinks(List<FavoritedDrink> favoritedDrinks)
    {
        List<IRenderable> iRenderables = [];

        foreach (var drink in favoritedDrinks)
            iRenderables.Add(new Markup(
                $"[{White}]Drink Name: [/][{Green}]{drink.StrDrink}[/] | [{White}]Id: [/][{Grey}]{drink.IdDrink}[/]"));

        return iRenderables;
    }

    private List<IRenderable> BuildViewedDrinks(List<ViewedDrink> viewedDrinks)
    {
        List<IRenderable> iRenderables = [];
        viewedDrinks = viewedDrinks.OrderByDescending(d => d.ViewCount).ToList();

        if (viewedDrinks.Count > appSettings.MaxLeaderboardSpots)
        {
            var viewedDrinksTrimmed = viewedDrinks.Take(appSettings.MaxLeaderboardSpots).ToList();
            foreach (var drink in viewedDrinksTrimmed)
                iRenderables.Add(new Markup(
                    $"[{White}]Drink Name: [/][{Green}]{drink.StrDrink}[/] | [{White}]Id: [/][{Grey}]{drink.IdDrink}[/] | [{White}]View Count: [/][{Grey}]{drink.ViewCount}[/]"));

            return iRenderables;
        }

        foreach (var drink in viewedDrinks)
            iRenderables.Add(new Markup(
                $"[{White}]Drink Name: [/][{Green}]{drink.StrDrink}[/] | [{White}]Id: [/][{Grey}]{drink.IdDrink}[/] | [{White}]View Count: [/][{Grey}]{drink.ViewCount}[/]"));

        return iRenderables;
    }
}