using drinksInfo._0lcm.ServiceContracts;
using Microsoft.Extensions.Logging;

namespace drinksInfo._0lcm.UserInterface;

public class ReviewCategoriesUi
{
    private readonly ILogger<ReviewCategoriesUi> _logger;
    private readonly IReviewCategoriesService _reviewCategoriesService;

    public ReviewCategoriesUi(IReviewCategoriesService reviewCategoriesService, ILogger<ReviewCategoriesUi> logger)
    {
        _reviewCategoriesService = reviewCategoriesService;
        _logger = logger;
    }

    //------- Menu Methods -------
    internal async Task ReviewMenu()
    {
        while (true)
        {
            Console.Clear();
            var option = DisplayHelper.DisplayMenu<Enums.Enums.ReviewCategoriesOption>();

            try
            {
                var shouldReturn = await HandleMenuOption(option);
                if (shouldReturn) return;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "An error occured during review menu");
                throw;
            }
        }
    }

    /// <summary>
    ///     Handles review menu options and returns true if user wants to leave the menu
    /// </summary>
    /// <param name="option"></param>
    /// <returns>a bool specifying true if the user wants to leave the menu</returns>
    private async Task<bool> HandleMenuOption(Enums.Enums.ReviewCategoriesOption option)
    {
        switch (option)
        {
            case Enums.Enums.ReviewCategoriesOption.SeeDrinks:
                await ViewDrinks();
                break;
            case Enums.Enums.ReviewCategoriesOption.SeeGlasses:
                await ViewGlasses();
                break;
            case Enums.Enums.ReviewCategoriesOption.SeeIngredients:
                await ViewIngredients();
                break;
            case Enums.Enums.ReviewCategoriesOption.SeeAlcoholicTypes:
                await ViewAlcoholContentCategory();
                break;
            case Enums.Enums.ReviewCategoriesOption.Back:
                return true;
        }

        return false;
    }

    //------- Viewing Methods -------

    /// <summary>
    ///     Shows the user a list of drink categories
    /// </summary>
    /// <param name="returnSelection">
    ///     Decides if the method should allow the user to select a drink category. set to false by
    ///     default
    /// </param>
    /// <returns>returns the string selected by the user if returnSelection is set to true, or returns empty string otherwise</returns>
    internal async Task<string> ViewDrinks(bool returnSelection = false)
    {
        Console.Clear();

        try
        {
            var categories = await _reviewCategoriesService.GetDrinkCategories();

            if (returnSelection)
            {
                List<string> drinkCategories = [];
                foreach (var drink in categories.Drinks) drinkCategories.Add(drink.StrCategory);

                var selection = DisplayHelper.DisplayPrompt(drinkCategories, "Please select a drink category:");
                return selection;
            }

            foreach (var drink in categories.Drinks) DisplayHelper.DisplayMessage(drink.StrCategory);

            DisplayHelper.DisplayPrompt(new List<string> { "Back" }, "\nPress Back to return:");
        }
        catch (HttpRequestException ex)
        {
            DisplayHelper.DisplayError($"\n\nAn error occurred: {ex.Message}. Press Enter to go back to the menu.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error has occurred while viewing drink categories");
            throw;
        }

        return string.Empty;
    }

    /// <summary>
    ///     Shows the user a list of glasses
    /// </summary>
    /// <param name="returnSelection">
    ///     Decides if the method should allow the user to select a type of glass. set to false by
    ///     default
    /// </param>
    /// <returns>returns the string selected by the user if returnSelection is set to true, or returns empty string otherwise</returns>
    internal async Task<string> ViewGlasses(bool returnSelection = false)
    {
        Console.Clear();

        try
        {
            var glasses = await _reviewCategoriesService.GetGlassesCategories();

            if (returnSelection)
            {
                List<string> glassesList = [];
                foreach (var glass in glasses.GlassCategory) glassesList.Add(glass.StrGlass);

                var selection = DisplayHelper.DisplayPrompt(glassesList, "Please select a type of glass:");
                return selection;
            }

            foreach (var glass in glasses.GlassCategory) DisplayHelper.DisplayMessage(glass.StrGlass);

            DisplayHelper.DisplayPrompt(new List<string> { "Back" }, "\nPress back to return:");
        }
        catch (HttpRequestException ex)
        {
            DisplayHelper.DisplayError($"\n\nAn Error occurred: {ex.Message}. Press enter to go back to the menu.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error occurred while viewing glasses.");
            throw;
        }

        return string.Empty;
    }

    /// <summary>
    ///     Shows the user a list of alcohol content levels
    /// </summary>
    /// <param name="returnSelection">
    ///     Decides if the method should allow the user to select a level of alcohol content. set to
    ///     false by default
    /// </param>
    /// <returns>returns the string selected by the user if returnSelection is set to true, or returns empty string otherwise</returns>
    internal async Task<string> ViewIngredients(bool returnSelection = false)
    {
        Console.Clear();

        try
        {
            var ingredients = await _reviewCategoriesService.GetIngredientCategories();

            if (returnSelection)
            {
                List<string> ingredientList = [];
                foreach (var ingredient in ingredients.IngredientCategory) ingredientList.Add(ingredient.StrIngredient);

                var selection = DisplayHelper.DisplayPrompt(ingredientList, "Please select an ingredient:");
                return selection;
            }

            foreach (var ingredient in ingredients.IngredientCategory)
                DisplayHelper.DisplayMessage(ingredient.StrIngredient);

            DisplayHelper.DisplayPrompt(new List<string> { "Back" }, "\nPress back to return:");
        }
        catch (HttpRequestException ex)
        {
            DisplayHelper.DisplayError($"An error occurred: {ex.Message}. Press enter to go back to the menu.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while viewing ingredients.");
            throw;
        }

        return string.Empty;
    }

    /// <summary>
    ///     Shows the user a list of alcohol content levels
    /// </summary>
    /// <param name="returnSelection">
    ///     Decides if the method should allow the user to select a level of alcohol content. set to
    ///     false by default
    /// </param>
    /// <returns>returns the string selected by the user if returnSelection is set to true, or returns empty string otherwise</returns>
    internal async Task<string> ViewAlcoholContentCategory(bool returnSelection = true)
    {
        Console.Clear();

        try
        {
            var alcoholContents = await _reviewCategoriesService.GetAlcoholContentCategories();

            if (returnSelection)
            {
                List<string> alcoholContentsList = [];
                foreach (var alcohol in alcoholContents.AlcoholContentCategory)
                    alcoholContentsList.Add(alcohol.StrAlcoholic);

                var selection = DisplayHelper.DisplayPrompt(alcoholContentsList,
                    "Please select an alcohol content level:");
                return selection;
            }

            foreach (var alcoholContent in alcoholContents.AlcoholContentCategory)
                DisplayHelper.DisplayMessage(alcoholContent.StrAlcoholic);

            DisplayHelper.DisplayPrompt(new List<string> { "Back" }, "\nPress back to return:");
        }
        catch (HttpRequestException ex)
        {
            DisplayHelper.DisplayError($"An error has occurred: {ex.Message}. Press enter to go back to the menu.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while viewing alcoholic content categories.");
            throw;
        }

        return string.Empty;
    }
}