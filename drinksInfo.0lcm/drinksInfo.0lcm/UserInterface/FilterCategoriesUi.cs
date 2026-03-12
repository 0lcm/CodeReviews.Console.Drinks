using drinksInfo._0lcm.Models;
using drinksInfo._0lcm.ServiceContracts;
using Microsoft.Extensions.Logging;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace drinksInfo._0lcm.UserInterface;

public class FilterCategoriesUi(
    IFilterCategoriesService filterService,
    ReviewCategoriesUi reviewCategoriesUi,
    ILogger<FilterCategoriesUi> logger)
{
    private readonly IFilterCategoriesService _filterService = filterService;
    private readonly ILogger _logger = logger;
    private readonly ReviewCategoriesUi _reviewCategoriesUi = reviewCategoriesUi;

    //------- Menu Methods -------
    internal async Task FilterCategories()
    {
        while (true)
        {
            Console.Clear();
            var option = DisplayHelper.DisplayMenu<Enums.Enums.FilterCategoriesOption>();

            try
            {
                var shouldReturn = await HandleMenuOption(option);
                if (shouldReturn) return;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while filtering categories.");
                throw;
            }
        }
    }

    /// <summary>
    ///     Handles the menu's option
    /// </summary>
    /// <param name="option"></param>
    /// <returns>returns true if the menu should return, and false if not</returns>
    private async Task<bool> HandleMenuOption(Enums.Enums.FilterCategoriesOption option)
    {
        switch (option)
        {
            case Enums.Enums.FilterCategoriesOption.FilterByAlcoholContent:
                await FilterByAlcoholContent();
                break;
            case Enums.Enums.FilterCategoriesOption.FilterByDrinkCategory:
                await FilterByDrinkCategory();
                break;
            case Enums.Enums.FilterCategoriesOption.FilterByGlassType:
                await FilterByGlassType();
                break;
            case Enums.Enums.FilterCategoriesOption.FilterByIngredient:
                await FilterByIngredient();
                break;
            case Enums.Enums.FilterCategoriesOption.Back:
                return true;
        }

        return false;
    }

    //------- Viewing Methods -------
    private async Task FilterByAlcoholContent()
    {
        Console.Clear();

        var selection = await _reviewCategoriesUi.ViewAlcoholContentCategory();
        var filterClass = await _filterService.FilterByAlcoholContent(selection);

        var rows = CreateFilterDisplayRows(filterClass);

        DisplayHelper.DisplayRows(rows);
        DisplayHelper.DisplayPrompt(new List<string> { "Back" }, "\nPress back to return:");
    }

    private async Task FilterByDrinkCategory()
    {
        Console.Clear();

        var selection = await _reviewCategoriesUi.ViewDrinks(true);
        var filterClass = await _filterService.FilterByDrinkCategory(selection);

        var rows = CreateFilterDisplayRows(filterClass);

        DisplayHelper.DisplayRows(rows);
        DisplayHelper.DisplayPrompt(new List<string> { "Back" }, "\nPress back to return:");
    }

    private async Task FilterByIngredient()
    {
        Console.Clear();

        var selection = await _reviewCategoriesUi.ViewIngredients(true);
        var filterClass = await _filterService.FilterByIngredient(selection);

        var rows = CreateFilterDisplayRows(filterClass);

        DisplayHelper.DisplayRows(rows);
        DisplayHelper.DisplayPrompt(new List<string> { "Back" }, "\nPress back to return:");
    }

    private async Task FilterByGlassType()
    {
        Console.Clear();

        var selection = await _reviewCategoriesUi.ViewGlasses(true);
        var filterClass = await _filterService.FilterByGlassType(selection);

        var rows = CreateFilterDisplayRows(filterClass);

        DisplayHelper.DisplayRows(rows);
        DisplayHelper.DisplayPrompt(new List<string> { "Back" }, "\nPress back to return:");
    }

    //------- Helper Methods -------
    private static List<IRenderable> CreateFilterDisplayRows(FilterClassResponse filterClass)
    {
        var rows = new List<IRenderable>();

        foreach (var filtered in filterClass.FilterElements)
            rows.Add(new Markup(
                $"[{DisplayHelper.White}]Drink Name: [/][{DisplayHelper.Green}]{filtered.StrDrink}[/] | " +
                $"[{DisplayHelper.White}]Drink Id: [/][{DisplayHelper.Grey}]{filtered.IdDrink}[/]"));

        return rows;
    }
}