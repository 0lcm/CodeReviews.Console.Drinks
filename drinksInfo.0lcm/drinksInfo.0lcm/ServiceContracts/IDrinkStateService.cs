using drinksInfo._0lcm.Models;

namespace drinksInfo._0lcm.ServiceContracts;

public interface IDrinkStateService
{
    public Task<bool> CheckDrinkIdIsFavorited(string id);
    public Task FavoriteDrink(LookupDrinkClassResponse? drinkClass);
    public Task RemoveFavorite(string id);
    public Task<List<FavoritedDrink>> GetFavorites();

    public Task AddViewCount(LookupDrinkClassResponse? drinkClass);
    public Task DeleteViewCounts();
    public Task<List<ViewedDrink>> GetViewedDrinks();
}