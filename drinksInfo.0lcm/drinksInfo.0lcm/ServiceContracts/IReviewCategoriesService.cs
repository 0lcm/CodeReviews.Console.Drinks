using drinksInfo._0lcm.Models;

namespace drinksInfo._0lcm.ServiceContracts;

public interface IReviewCategoriesService
{
    public Task<DrinkCategoryResponse> GetDrinkCategories();
    public Task<GlassCategoryResponse> GetGlassesCategories();
    public Task<IngredientCategoryResponse> GetIngredientCategories();
    public Task<AlcoholContentCategoryResponse> GetAlcoholContentCategories();
}