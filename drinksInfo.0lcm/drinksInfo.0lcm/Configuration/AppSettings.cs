namespace drinksInfo._0lcm.Configuration;

public class AppSettings
{
    public bool ShowImages { get; set; } = true;
    public bool ShowImagesDefault { get; } = true;
    public int MaxImageWidth { get; set; } = 25;
    public int MaxImageWidthDefault { get; } = 25;
    public bool StoreDrinkCounts { get; set; } = true;
    public bool StoreDrinkCountsDefault { get; } = true;
    public int MaxLeaderboardSpots { get; set; } = 20;
    public int MaxLeaderboardSpotsDefault { get; } = 20;
}