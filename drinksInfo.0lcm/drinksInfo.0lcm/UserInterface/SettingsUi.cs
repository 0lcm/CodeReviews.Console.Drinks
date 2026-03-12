using drinksInfo._0lcm.Configuration;
using drinksInfo._0lcm.ServiceContracts;

namespace drinksInfo._0lcm.UserInterface;

public class SettingsUi(ISettingsService settingsService, AppSettings appSettings)
{
    private readonly ISettingsService _settingsService = settingsService;

    //------- Menu Methods -------
    internal void Settings()
    {
        while (true)
        {
            Console.Clear();
            var showImagesDescription =
                @$"* Show Images - turn images on/off when searching drinks. |Currently: {appSettings.ShowImages}|
Turning off images can increase app performance in some cases.";
            var imageMaxWidthDescription =
                $@"* Change Image Max Width - limits the images to a certain width. |Currently: {appSettings.MaxImageWidth}|
A higher max width can make the image more detailed, but can also decrease performance.";
            var storeViewCountsDescription =
                $"* Store View Counts - allows storing view counts for searched drinks |Currently: {appSettings.StoreDrinkCounts}|";
            var maxLeaderboardSpotsDescription =
                $"* Max Leaderboard Spots - Changed the max amount of drinks that can be displayed in the view count leaderboard (1-50) |Currently: {appSettings.MaxLeaderboardSpots}|";
            DisplayHelper.DisplayMessage(
                $"\n{showImagesDescription}\n\n{imageMaxWidthDescription}\n\n{storeViewCountsDescription}\n\n{maxLeaderboardSpotsDescription}");
            var option = DisplayHelper.DisplayMenu<Enums.Enums.SettingsMenuOption>("\nPlease select an option:");

            var shouldReturn = HandleMenuOption(option);
            if (shouldReturn) return;
        }
    }

    /// <summary>
    ///     Handles menu option
    /// </summary>
    /// <param name="option"></param>
    /// <returns>true if the menu should return, else false</returns>
    private bool HandleMenuOption(Enums.Enums.SettingsMenuOption option)
    {
        switch (option)
        {
            case Enums.Enums.SettingsMenuOption.ToggleShowImages:
                ToggleShowImages();
                break;
            case Enums.Enums.SettingsMenuOption.ChangeImageMaxWidth:
                ChangeMaxWidth();
                break;
            case Enums.Enums.SettingsMenuOption.ToggleStoreViewCounts:
                ToggleStoreViewCounts();
                break;
            case Enums.Enums.SettingsMenuOption.ChangeMaxLeaderboardSpots:
                ChangeMaxLeaderboardSpots();
                break;
            case Enums.Enums.SettingsMenuOption.ResetSettings:
                ResetSettings();
                break;
            case Enums.Enums.SettingsMenuOption.Back:
                return true;
        }

        return false;
    }

    //------- Setting Methods -------
    private void ToggleShowImages()
    {
        Console.Clear();
        _settingsService.ToggleShowImages();

        if (appSettings.ShowImages)
            DisplayHelper.DisplaySuccess("Images will now be shown when searching drinks.");
        else
            DisplayHelper.DisplaySuccess("Images will now be hidden when searching drinks.");

        DisplayHelper.DisplayMessage("Press enter to continue.");
        Console.ReadLine();
    }

    private void ChangeMaxWidth()
    {
        while (true)
        {
            Console.Clear();
            var maxWidth = DisplayHelper.DisplayQuestion("Please enter a new max width (1-100):");

            if (string.IsNullOrEmpty(maxWidth))
            {
                DisplayWarning("Please enter a non null value");
                continue;
            }

            if (!int.TryParse(maxWidth, out var newMaxWidth))
            {
                DisplayWarning("Please enter a number");
                continue;
            }

            if (newMaxWidth > 100 || newMaxWidth < 1)
            {
                DisplayWarning("Please enter a number between 1 and 100");
                continue;
            }

            _settingsService.ChangeMaxWidth(newMaxWidth);

            DisplayHelper.DisplaySuccess("\nMax width has been changed.");
            DisplayHelper.DisplayMessage("Press enter to continue.");
            Console.ReadLine();
            return;
        }
    }

    private void ToggleStoreViewCounts()
    {
        Console.Clear();
        _settingsService.ToggleStoreViewCounts();

        if (appSettings.StoreDrinkCounts)
            DisplayHelper.DisplaySuccess("View counts will now be stored locally.");
        else
            DisplayHelper.DisplaySuccess("View counts will no longer be stored.");

        DisplayHelper.DisplayMessage("Press enter to continue.");
        Console.ReadLine();
    }

    private void ChangeMaxLeaderboardSpots()
    {
        while (true)
        {
            Console.Clear();
            var maxSpots = DisplayHelper.DisplayQuestion("Please enter a new amount of max leaderboard spots (1-50):");

            if (string.IsNullOrEmpty(maxSpots))
            {
                DisplayWarning("Please enter a non null value");
                continue;
            }

            if (!int.TryParse(maxSpots, out var newMaxSpots))
            {
                DisplayWarning("Please enter a number");
                continue;
            }

            if (newMaxSpots > 50 || newMaxSpots < 1)
            {
                DisplayWarning("Please enter a number between 1 and 50");
                continue;
            }

            _settingsService.ChangeMaxLeaderboardSpots(newMaxSpots);

            DisplayHelper.DisplaySuccess("\nThe max amount of leaderboard spots has been changed.");
            DisplayHelper.DisplayMessage("Press enter to continue.");
            Console.ReadLine();
            return;
        }
    }

    private void ResetSettings()
    {
        _settingsService.ResetSettings();

        DisplayHelper.DisplaySuccess("Settings have been reset.");
        DisplayHelper.DisplayMessage("Press enter to continue.");
        Console.ReadLine();
    }

    //------- Helper Methods -------
    private void DisplayWarning(string warningMessage)
    {
        DisplayHelper.DisplayWarning(warningMessage);
        DisplayHelper.DisplayMessage("Press enter to continue.");
        Console.ReadLine();
    }
}