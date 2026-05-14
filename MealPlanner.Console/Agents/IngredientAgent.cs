using MealPlanner.Console.Models;

namespace MealPlanner.Console.Agents;

public class IngredientAgent
{
    public List<Ingredient> ProcessIngredients(string input)
    {
        return input
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(i => new Ingredient
            {
                Name = i.Trim().ToLower()
            })
            .ToList();
    }
}