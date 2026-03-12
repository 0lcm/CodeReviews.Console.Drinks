using Microsoft.Extensions.Logging;

namespace drinksInfo._0lcm.UserInterface;

public class ConsoleUi(
    ReviewCategoriesUi reviewCategoriesUi,
    FilterCategoriesUi filterCategoriesUi,
    LookupSpecificsUi lookupSpecificsUi,
    SettingsUi settingsUi,
    FavoritesAndLeaderboardUi favoritesAndLeaderboardUi,
    ILogger<ConsoleUi> logger)
{
    private readonly FavoritesAndLeaderboardUi _favoritesAndLeaderboardUi = favoritesAndLeaderboardUi;
    private readonly FilterCategoriesUi _filterCategoriesUi = filterCategoriesUi;
    private readonly ILogger _logger = logger;
    private readonly LookupSpecificsUi _lookupSpecificsUi = lookupSpecificsUi;
    private readonly ReviewCategoriesUi _reviewCategoriesUi = reviewCategoriesUi;
    private readonly SettingsUi _settingsUi = settingsUi;


    //------- Main Menu Methods -------
    internal async Task MainMenu()
    {
        while (true)
        {
            Console.Clear();
            var option = DisplayHelper.DisplayMenu<Enums.Enums.MainMenuOption>();

            try
            {
                await HandleMainMenu(option);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception caught in the main menu loop.");

                DisplayHelper.DisplayError("\n\nAn error has occured, please press enter to go back to the main menu.");
                Console.ReadLine();
            }
        }
    }

    private async Task HandleMainMenu(Enums.Enums.MainMenuOption option)
    {
        switch (option)
        {
            case Enums.Enums.MainMenuOption.LookupBySpecifics:
                await _lookupSpecificsUi.LookupSpecifics();
                break;
            case Enums.Enums.MainMenuOption.FilterByCategories:
                await _filterCategoriesUi.FilterCategories();
                break;
            case Enums.Enums.MainMenuOption.ReviewCategories:
                await _reviewCategoriesUi.ReviewMenu();
                break;
            case Enums.Enums.MainMenuOption.SeeFavoritesAndViewCounts:
                await _favoritesAndLeaderboardUi.FavoritesAndLeaderboard();
                break;
            case Enums.Enums.MainMenuOption.Settings:
                _settingsUi.Settings();
                break;
            case Enums.Enums.MainMenuOption.Exit:
                await ExitApplication();
                break;
        }
    }

    private static async Task ExitApplication()
    {
        await DisplayHelper.DisplaySpinner("Exiting console..", 2500);
        Environment.Exit(0);
    }
}