using System.Text.Json;
using drinksInfo._0lcm.Models;
using drinksInfo._0lcm.ServiceContracts;

namespace drinksInfo._0lcm.Services;

public class ReviewCategoriesCategoriesService(ApiService apiService) : IReviewCategoriesService
{
    private readonly ApiService _apiService = apiService;

    public async Task<DrinkCategoryResponse> GetDrinkCategories()
    {
        var rawJson = await _apiService.GetCategories();

        return JsonSerializer.Deserialize<DrinkCategoryResponse>(rawJson)!;
    }

    public async Task<GlassCategoryResponse> GetGlassesCategories()
    {
        var rawJson = await _apiService.GetGlasses();

        return JsonSerializer.Deserialize<GlassCategoryResponse>(rawJson)!;
    }

    public async Task<IngredientCategoryResponse> GetIngredientCategories()
    {
        var rawJson = await _apiService.GetIngredients();

        return JsonSerializer.Deserialize<IngredientCategoryResponse>(rawJson)!;
    }

    public async Task<AlcoholContentCategoryResponse> GetAlcoholContentCategories()
    {
        var rawJson = await _apiService.GetAlcoholContentCategory();

        return JsonSerializer.Deserialize<AlcoholContentCategoryResponse>(rawJson)!;
    }
}