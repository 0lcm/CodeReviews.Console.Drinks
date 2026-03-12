using System.Text.Json;
using drinksInfo._0lcm.Models;
using drinksInfo._0lcm.ServiceContracts;

namespace drinksInfo._0lcm.Services;

public class FilterCategoriesService(ApiService apiService) : IFilterCategoriesService
{
    private readonly ApiService _apiService = apiService;

    public async Task<FilterClassResponse> FilterByGlassType(string path)
    {
        var rawJson = await _apiService.FilterForGlassesByPath(path);

        return JsonSerializer.Deserialize<FilterClassResponse>(rawJson)!;
    }

    public async Task<FilterClassResponse> FilterByDrinkCategory(string path)
    {
        var rawJson = await _apiService.FilterForDrinkCategoryByPath(path);

        return JsonSerializer.Deserialize<FilterClassResponse>(rawJson)!;
    }

    public async Task<FilterClassResponse> FilterByAlcoholContent(string path)
    {
        var rawJson = await _apiService.FilterForAlcoholContentByPath(path);

        return JsonSerializer.Deserialize<FilterClassResponse>(rawJson)!;
    }

    public async Task<FilterClassResponse> FilterByIngredient(string path)
    {
        var rawJson = await _apiService.FilterForIngredientByPath(path);

        return JsonSerializer.Deserialize<FilterClassResponse>(rawJson)!;
    }
}