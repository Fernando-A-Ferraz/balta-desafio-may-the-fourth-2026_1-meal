using MealPlanner.Console.Agents;
using MealPlanner.Console.Models;

namespace MealPlanner.Console.Services;

public class MealPlannerService
{
    private readonly IngredientAgent _ingredientAgent = new();
    private readonly ScheduleAgent _scheduleAgent = new();
    private readonly RecipeAgent _recipeAgent = new();

    public RecipeSuggestion SuggestRecipe(string ingredientInput, int availableMinutes)
    {
        var ingredients = _ingredientAgent.ProcessIngredients(ingredientInput);
        var availableTime = _scheduleAgent.ProcessTime(availableMinutes);

        return _recipeAgent.SuggestRecipe(ingredients, availableTime);
    }
}