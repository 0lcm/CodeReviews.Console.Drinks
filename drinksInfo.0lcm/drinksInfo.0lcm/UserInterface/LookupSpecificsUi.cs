using drinksInfo._0lcm.Configuration;
using drinksInfo._0lcm.Models;
using drinksInfo._0lcm.ServiceContracts;
using Microsoft.Extensions.Logging;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace drinksInfo._0lcm.UserInterface;

public class LookupSpecificsUi(
    ILookupSpecificsService lookupService,
    ILogger<LookupSpecificsUi> logger,
    AppSettings appSettings,
    IDrinkStateService drinkStateService)
{
    private const string PromptOptionAddFavorite = "Favorite Drink";
    private const string PromptOptionRemoveFavorite = "Remove Drink From Favorites";
    private const string PromptOptionBack = "Back";
    private readonly IDrinkStateService _drinkStateService = drinkStateService;
    private readonly ILogger _logger = logger;
    private readonly ILookupSpecificsService _lookupService = lookupService;

    //------- Menu Methods -------
    internal async Task LookupSpecifics()
    {
        while (true)
        {
            Console.Clear();
            try
            {
                Console.Clear();
                var option = DisplayHelper.DisplayMenu<Enums.Enums.LookupSpecificsOption>();

                var shouldReturn = await HandleMenuOption(option);
                if (shouldReturn) return;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception caught while looking up specifics");
                throw;
            }
        }
    }

    /// <summary>
    ///     Handles the menu options
    /// </summary>
    /// <param name="option"></param>
    /// <returns>Returns true if the menu should return, false if not.</returns>
    private async Task<bool> HandleMenuOption(Enums.Enums.LookupSpecificsOption option)
    {
        switch (option)
        {
            case Enums.Enums.LookupSpecificsOption.LookupCocktailByName:
                await LookupCocktailByName();
                break;
            case Enums.Enums.LookupSpecificsOption.LookupIngredientByName:
                await LookupIngredientByName();
                break;
            case Enums.Enums.LookupSpecificsOption.LookupCocktailById:
                await LookupCocktailById();
                break;
            case Enums.Enums.LookupSpecificsOption.LookupIngredientById:
                await LookupIngredientById();
                break;
            case Enums.Enums.LookupSpecificsOption.LookupRandomCocktail:
                await LookupRandomCocktail();
                break;
            case Enums.Enums.LookupSpecificsOption.Back:
                return true;
        }

        return false;
    }

    //------- Viewing Methods -------
    private async Task LookupCocktailByName()
    {
        while (true)
        {
            Console.Clear();
            var lookupDetail = GetStringInput();

            try
            {
                Console.Clear();
                var drinkInfo = await _lookupService.LookupCocktailByName(lookupDetail);

                var rows = await CreateDrinkRows(drinkInfo);
                DisplayHelper.DisplayRows(rows);

                var promptList = await CreatePromptList(drinkInfo);
                var option = DisplayHelper.DisplayPrompt(promptList, "\nPlease select an option:");

                await HandleDrinkStateChanges(option, drinkInfo);
            }
            catch (HttpRequestException ex)
            {
                var shouldContinue = CatchHttpRequestException(ex);

                if (shouldContinue) continue;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Exception caught while looking up cocktail by name.");
                throw;
            }

            return;
        }
    }

    private async Task LookupCocktailById()
    {
        while (true)
        {
            Console.Clear();
            var lookupDetail = GetStringInput();

            try
            {
                Console.Clear();
                var drinkInfo = await _lookupService.LookupCocktailById(lookupDetail);

                var rows = await CreateDrinkRows(drinkInfo);
                DisplayHelper.DisplayRows(rows);

                var promptList = await CreatePromptList(drinkInfo);
                var option = DisplayHelper.DisplayPrompt(promptList, "\nPlease select an option:");

                await HandleDrinkStateChanges(option, drinkInfo);
            }
            catch (HttpRequestException ex)
            {
                var shouldContinue = CatchHttpRequestException(ex);

                if (shouldContinue) continue;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Exception caught while looking up cocktail by name.");
                throw;
            }

            return;
        }
    }

    private async Task LookupIngredientByName()
    {
        while (true)
        {
            Console.Clear();
            var lookupDetail = GetStringInput();

            try
            {
                Console.Clear();
                var ingredientInfo = await _lookupService.LookupIngredientByName(lookupDetail);

                var rows = CreateIngredientRows(ingredientInfo);
                DisplayHelper.DisplayRows(rows);

                var promptList = await CreatePromptList(null);
                DisplayHelper.DisplayPrompt(promptList, "\nPlease select an option:");
            }
            catch (HttpRequestException ex)
            {
                var shouldContinue = CatchHttpRequestException(ex);

                if (shouldContinue) continue;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Exception caught while looking up ingredient by name.");
                throw;
            }

            return;
        }
    }

    private async Task LookupIngredientById()
    {
        while (true)
        {
            Console.Clear();
            var lookupDetail = GetStringInput();

            try
            {
                Console.Clear();
                var ingredientInfo = await _lookupService.LookupIngredientById(lookupDetail);

                var rows = CreateIngredientRows(ingredientInfo);
                DisplayHelper.DisplayRows(rows);

                var promptList = await CreatePromptList(null);
                DisplayHelper.DisplayPrompt(promptList, "\nPlease select an option:");
            }
            catch (HttpRequestException ex)
            {
                var shouldContinue = CatchHttpRequestException(ex);

                if (shouldContinue) continue;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Exception caught while looking up ingredient by name.");
                throw;
            }

            return;
        }
    }

    private async Task LookupRandomCocktail()
    {
        while (true)
        {
            Console.Clear();
            try
            {
                Console.Clear();
                var drinkInfo = await _lookupService.LookupRandomCocktail();

                var rows = await CreateDrinkRows(drinkInfo);
                DisplayHelper.DisplayRows(rows);

                var promptList = await CreatePromptList(drinkInfo);
                var option = DisplayHelper.DisplayPrompt(promptList, "\nPlease select an option:");

                await HandleDrinkStateChanges(option, drinkInfo);
            }
            catch (HttpRequestException ex)
            {
                var shouldContinue = CatchHttpRequestException(ex);

                if (shouldContinue) continue;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Exception caught while looking up cocktail by name.");
                throw;
            }

            return;
        }
    }

    //------- Helper Methods -------
    private static string GetStringInput()
    {
        while (true)
        {
            Console.Clear();
            var response = DisplayHelper.DisplayQuestion("Please enter a name/id for lookup:");

            if (string.IsNullOrEmpty(response))
            {
                DisplayHelper.DisplayWarning("Lookup cannot be null or empty. Press enter to continue.");
                Console.ReadLine();
                continue;
            }

            var confirmation = AnsiConsole.Confirm($"Is: {response} the correct name/id?");
            if (!confirmation) continue;

            return response;
        }
    }

    private async Task<List<IRenderable>> CreateDrinkRows(LookupDrinkClassResponse? drinkClass)
    {
        List<IRenderable> rows = [];

        foreach (var drink in drinkClass!.Drinks)
        {
            rows.Add(new Markup($"[{DisplayHelper.Grey}]\n--------------------------------------------------[/]\n"));

            if (!string.IsNullOrEmpty(drink.StrDrinkThumb) && appSettings.ShowImages)
            {
                var image = await _lookupService.CreateCanvasImageFromUrl(drink.StrDrinkThumb);
                rows.Add(image);
            }

            foreach (var (field, value) in drink.DrinkInfo)
                rows.Add(new Markup($"[{DisplayHelper.White}]{field}: [/][{DisplayHelper.Green}]{value}[/]"));
        }

        return rows;
    }

    private static List<IRenderable> CreateIngredientRows(LookupIngredientClassResponse? ingredientClass)
    {
        List<IRenderable> rows = [];

        foreach (var ingredient in ingredientClass!.Ingredients)
        foreach (var (field, value) in ingredient.IngredientInfo)
            rows.Add(new Markup($"[{DisplayHelper.White}]{field}: [/][{DisplayHelper.Green}]{value}[/]"));

        return rows;
    }

    private async Task<List<string>> CreatePromptList(LookupDrinkClassResponse? drinkClass)
    {
        List<string> promptList = [];

        if (drinkClass?.Drinks is { Count: 1 } drinks)
        {
            var isFavorited = await _drinkStateService.CheckDrinkIdIsFavorited(drinks[0].IdDrink!);
            promptList.Add(!isFavorited ? PromptOptionAddFavorite : PromptOptionRemoveFavorite);
        }

        promptList.Add(PromptOptionBack);
        return promptList;
    }

    /// <summary>
    ///     catches and deals with an HttpRequestException
    /// </summary>
    /// <param name="ex"></param>
    /// <returns>true if the user wants to restart the search, false if not</returns>
    private static bool CatchHttpRequestException(HttpRequestException ex)
    {
        if ((int)ex.StatusCode! == 404)
        {
            Console.Clear();
            DisplayHelper.DisplayWarning("A 404: Not found exception was received, " +
                                         "please make sure you check for correct spelling, " +
                                         "or make sure the drink is in the database.");
        }
        else
        {
            DisplayHelper.DisplayWarning(ex.Message);
        }

        return AnsiConsole.Confirm("Would you like to retry the search?");
    }

    /// <summary>
    ///     Takes the action prompt's action option and takes applicable actions, and then updates drink view count.
    /// </summary>
    /// <param name="option">action prompt's output</param>
    /// <param name="drinkClass"></param>
    private async Task HandleDrinkStateChanges(string option, LookupDrinkClassResponse? drinkClass)
    {
        switch (option)
        {
            case PromptOptionAddFavorite:
                await _drinkStateService.FavoriteDrink(drinkClass);
                break;
            case PromptOptionRemoveFavorite:
                await _drinkStateService.RemoveFavorite(drinkClass!.Drinks[0].IdDrink!);
                break;
        }

        await _drinkStateService.AddViewCount(drinkClass);
    }
}