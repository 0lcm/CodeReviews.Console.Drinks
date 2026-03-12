using drinksInfo._0lcm.Models;
using Microsoft.Extensions.Logging;

namespace drinksInfo._0lcm.Services;

public class ApiService(IHttpClientFactory httpClientFactory, ILogger<ApiService> logger)
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly ILogger _logger = logger;

    //------- Lookup Methods -------
    internal async Task<string> LookupCocktailByName(string name)
    {
        return await GetAsync($"{ApiConstants.IncompleteLookupCocktailByNamePath}{name}");
    }

    internal async Task<string> LookupIngredientByName(string name)
    {
        return await GetAsync($"{ApiConstants.IncompleteLookupIngredientByNamePath}{name}");
    }

    internal async Task<string> LookupCocktailById(string id)
    {
        return await GetAsync($"{ApiConstants.IncompleteLookupCocktailByIdPath}{id}");
    }

    internal async Task<string> LookupIngredientById(string id)
    {
        return await GetAsync($"{ApiConstants.IncompleteLookupIngredientByIdPath}{id}");
    }

    internal async Task<string> LookupRandomCocktail()
    {
        return await GetAsync(ApiConstants.LookupRandomCocktailPath);
    }

    //------- Filter Methods -------
    internal async Task<string> FilterForAlcoholContentByPath(string path)
    {
        return await GetAsync($"{ApiConstants.IncompleteAlcoholContentFilterPath}{path}");
    }

    internal async Task<string> FilterForDrinkCategoryByPath(string path)
    {
        return await GetAsync($"{ApiConstants.IncompleteCategoryFilterPath}{path}");
    }

    internal async Task<string> FilterForGlassesByPath(string path)
    {
        return await GetAsync($"{ApiConstants.IncompleteGlassFilterPath}{path}");
    }

    internal async Task<string> FilterForIngredientByPath(string path)
    {
        return await GetAsync($"{ApiConstants.IncompleteIngredientFilterPath}{path}");
    }

    //------- Category List Methods -------
    internal async Task<string> GetCategories()
    {
        return await GetAsync(ApiConstants.DrinkCategoriesPath);
    }

    internal async Task<string> GetGlasses()
    {
        return await GetAsync(ApiConstants.GlassCategoriesPath);
    }

    internal async Task<string> GetIngredients()
    {
        return await GetAsync(ApiConstants.IngredientCategoriesPath);
    }

    internal async Task<string> GetAlcoholContentCategory()
    {
        return await GetAsync(ApiConstants.AlcoholContentCategoryPath);
    }

    //------- Image Methods -------
    internal async Task<byte[]> DownloadImageBytes(string path)
    {
        var client = _httpClientFactory.CreateClient();
        return await client.GetByteArrayAsync(path);
    }

    //------- Helper Methods -------
    private async Task<string> GetAsync(string path)
    {
        var client = _httpClientFactory.CreateClient(ApiConstants.ApiName);
        var response = await client.GetAsync(path);

        return await HandleResponse(response);
    }

    private async Task<string> HandleResponse(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode) return await response.Content.ReadAsStringAsync();

        if ((int)response.StatusCode == 418)
            throw new HttpRequestException("This server is not a teapot and refuses to brew coffee", null,
                response.StatusCode);

        if ((int)response.StatusCode >= 400 && (int)response.StatusCode < 500)
            throw new HttpRequestException($"Client side error: {response.StatusCode}", null, response.StatusCode);

        if ((int)response.StatusCode >= 500)
            throw new HttpRequestException($"Server side error: {response.StatusCode}", null, response.StatusCode);

        _logger.LogWarning("Unexpected status code occurred from API: {StatusCode}", response.StatusCode);
        return string.Empty;
    }
}