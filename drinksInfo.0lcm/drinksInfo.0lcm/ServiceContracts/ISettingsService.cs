namespace drinksInfo._0lcm.ServiceContracts;

public interface ISettingsService
{
    public void ToggleShowImages();
    public void ChangeMaxWidth(int width);
    public void ResetSettings();
    public void ToggleStoreViewCounts();
    public void ChangeMaxLeaderboardSpots(int maxLeaderboardSpots);
}