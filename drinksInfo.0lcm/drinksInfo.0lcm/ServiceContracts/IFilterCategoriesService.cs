using drinksInfo._0lcm.Models;

namespace drinksInfo._0lcm.ServiceContracts;

public interface IFilterCategoriesService
{
    public Task<FilterClassResponse> FilterByGlassType(string path);
    public Task<FilterClassResponse> FilterByDrinkCategory(string path);
    public Task<FilterClassResponse> FilterByAlcoholContent(string path);
    public Task<FilterClassResponse> FilterByIngredient(string path);
}