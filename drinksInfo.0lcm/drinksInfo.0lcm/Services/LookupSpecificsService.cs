using System.Net;
using System.Text.Json;
using drinksInfo._0lcm.Configuration;
using drinksInfo._0lcm.Models;
using drinksInfo._0lcm.ServiceContracts;
using Spectre.Console;

namespace drinksInfo._0lcm.Services;

public class LookupSpecificsService(ApiService apiService, AppSettings appSettings) : ILookupSpecificsService
{
    private readonly ApiService _apiService = apiService;

    public async Task<LookupDrinkClassResponse> LookupCocktailByName(string name)
    {
        var rawJson = await _apiService.LookupCocktailByName(name);

        var result = JsonSerializer.Deserialize<LookupDrinkClassResponse>(rawJson)!;

        if (result?.Drinks == null)
            throw new HttpRequestException("Client side error: 404 not found", null, HttpStatusCode.NotFound);
        return result;
    }

    public async Task<LookupIngredientClassResponse> LookupIngredientByName(string name)
    {
        var rawJson = await _apiService.LookupIngredientByName(name);


        var result = JsonSerializer.Deserialize<LookupIngredientClassResponse>(rawJson)!;

        if (result?.Ingredients == null)
            throw new HttpRequestException("Client side error: 404 not found", null, HttpStatusCode.NotFound);

        return result;
    }

    public async Task<LookupDrinkClassResponse> LookupCocktailById(string id)
    {
        var rawJson = await _apiService.LookupCocktailById(id);

        var result = JsonSerializer.Deserialize<LookupDrinkClassResponse>(rawJson)!;

        if (result?.Drinks == null)
            throw new HttpRequestException("Client side error: 404 not found", null, HttpStatusCode.NotFound);

        return result;
    }

    public async Task<LookupIngredientClassResponse> LookupIngredientById(string id)
    {
        var rawJson = await _apiService.LookupIngredientById(id);

        var result = JsonSerializer.Deserialize<LookupIngredientClassResponse>(rawJson)!;

        if (result?.Ingredients == null)
            throw new HttpRequestException("Client side error: 404 not found", null, HttpStatusCode.NotFound);

        return result;
    }

    public async Task<LookupDrinkClassResponse> LookupRandomCocktail()
    {
        var rawJson = await _apiService.LookupRandomCocktail();

        var result = JsonSerializer.Deserialize<LookupDrinkClassResponse>(rawJson)!;

        if (result?.Drinks == null)
            throw new HttpRequestException("Client side error: 404 not found", null, HttpStatusCode.NotFound);

        return result;
    }

    public async Task<CanvasImage> CreateCanvasImageFromUrl(string path)
    {
        var imageBytes = await _apiService.DownloadImageBytes(path);
        var image = new CanvasImage(imageBytes);

        image.MaxWidth(appSettings.MaxImageWidth);
        return image;
    }
}