using drinksInfo._0lcm.Configuration;
using drinksInfo._0lcm.ServiceContracts;

namespace drinksInfo._0lcm.Services;

public class SettingsService(
    AppSettings appSettings,
    SettingsManager settingsManager,
    IDrinkStateService drinkStateService) : ISettingsService
{
    private readonly IDrinkStateService _drinkStateService = drinkStateService;

    public void ToggleShowImages()
    {
        appSettings.ShowImages = !appSettings.ShowImages;

        settingsManager.Save(appSettings);
    }

    public void ChangeMaxWidth(int width)
    {
        appSettings.MaxImageWidth = width;

        settingsManager.Save(appSettings);
    }

    public void ToggleStoreViewCounts()
    {
        appSettings.StoreDrinkCounts = !appSettings.StoreDrinkCounts;

        if (!appSettings.StoreDrinkCounts) _drinkStateService.DeleteViewCounts();

        settingsManager.Save(appSettings);
    }

    public void ChangeMaxLeaderboardSpots(int maxLeaderboardSpots)
    {
        appSettings.MaxLeaderboardSpots = maxLeaderboardSpots;

        settingsManager.Save(appSettings);
    }

    public void ResetSettings()
    {
        appSettings.ShowImages = appSettings.ShowImagesDefault;
        appSettings.MaxImageWidth = appSettings.MaxImageWidthDefault;
        appSettings.StoreDrinkCounts = appSettings.StoreDrinkCountsDefault;
        appSettings.MaxLeaderboardSpots = appSettings.MaxLeaderboardSpotsDefault;

        settingsManager.Save(appSettings);
    }
}