using drinksInfo._0lcm.Models;
using Spectre.Console;

namespace drinksInfo._0lcm.ServiceContracts;

public interface ILookupSpecificsService
{
    public Task<LookupDrinkClassResponse> LookupCocktailByName(string name);
    public Task<LookupIngredientClassResponse> LookupIngredientByName(string ingredient);
    public Task<LookupDrinkClassResponse> LookupCocktailById(string ingredient);
    public Task<LookupIngredientClassResponse> LookupIngredientById(string ingredient);
    public Task<LookupDrinkClassResponse> LookupRandomCocktail();
    public Task<CanvasImage> CreateCanvasImageFromUrl(string path);
}