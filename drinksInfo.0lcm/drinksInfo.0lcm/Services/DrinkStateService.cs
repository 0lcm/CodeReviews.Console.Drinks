using drinksInfo._0lcm.Configuration;
using drinksInfo._0lcm.Models;
using drinksInfo._0lcm.ServiceContracts;
using Microsoft.EntityFrameworkCore;

namespace drinksInfo._0lcm.Services;

public class DrinkStateService(AppDbContext db, AppSettings appSettings) : IDrinkStateService
{
    //------- Favorite Drink Methods -------
    public async Task<bool> CheckDrinkIdIsFavorited(string id)
    {
        var isFavorited = await db.FavoritedDrinks.AnyAsync(d => d.IdDrink == id);

        return isFavorited;
    }

    public async Task FavoriteDrink(LookupDrinkClassResponse? drinkClass)
    {
        var drink = drinkClass!.Drinks[0];

        var isFavorited = await CheckDrinkIdIsFavorited(drink.IdDrink!);
        if (isFavorited) return;

        db.FavoritedDrinks.Add(new FavoritedDrink { IdDrink = drink.IdDrink!, StrDrink = drink.StrDrink! });
        await db.SaveChangesAsync();
    }

    public async Task RemoveFavorite(string id)
    {
        var drink = await db.FavoritedDrinks.FirstOrDefaultAsync(d => d.IdDrink == id);
        if (drink == null) return;

        db.FavoritedDrinks.Remove(drink);
        await db.SaveChangesAsync();
    }

    public async Task<List<FavoritedDrink>> GetFavorites()
    {
        return await db.FavoritedDrinks.ToListAsync();
    }

    //------- View Count Methods -------
    public async Task AddViewCount(LookupDrinkClassResponse? drinkClass)
    {
        if (!appSettings.StoreDrinkCounts) return;

        var drink = drinkClass!.Drinks[0];
        var existingDrink = await db.ViewedDrinks.FirstOrDefaultAsync(d => d.IdDrink == drink.IdDrink);

        if (existingDrink is null)
            db.ViewedDrinks.Add(new ViewedDrink { IdDrink = drink.IdDrink!, StrDrink = drink.StrDrink! });
        else
            existingDrink.ViewCount++;

        await db.SaveChangesAsync();
    }

    public async Task DeleteViewCounts()
    {
        db.ViewedDrinks.RemoveRange(db.ViewedDrinks);
        await db.SaveChangesAsync();
    }

    public async Task<List<ViewedDrink>> GetViewedDrinks()
    {
        return await db.ViewedDrinks.ToListAsync();
    }
}