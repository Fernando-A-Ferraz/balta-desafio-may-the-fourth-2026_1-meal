using MealPlanner.Console.Models;

namespace MealPlanner.Console.Agents;

public class RecipeAgent
{
    public RecipeSuggestion SuggestRecipe(
        List<Ingredient> ingredients,
        AvailableTime availableTime)
    {
        var ingredientNames = ingredients
            .Select(i => i.Name)
            .ToList();

        var recipes = new List<RecipeSuggestion>
        {
            new()
            {
                RecipeName = "Misto quente com ovo",
                EstimatedTime = 10,
                Ingredients = ["pão", "ovo", "queijo"]
            },

            new()
            {
                RecipeName = "Misto quente simples",
                EstimatedTime = 5,
                Ingredients = ["pão", "queijo"]
            },

            new()
            {
                RecipeName = "Ovo mexido",
                EstimatedTime = 5,
                Ingredients = ["ovo"]
            },

            new()
            {
                RecipeName = "Sanduíche de presunto e queijo",
                EstimatedTime = 8,
                Ingredients = ["pão", "presunto", "queijo"]
            },

            new()
            {
                RecipeName = "Macarrão rápido",
                EstimatedTime = 20,
                Ingredients = ["macarrão", "molho"]
            },

            new()
            {
                RecipeName = "Arroz e feijão",
                EstimatedTime = 15,
                Ingredients = ["arroz", "feijão"]
            }
        };

        var availableRecipes = recipes
            .Where(recipe =>
                recipe.EstimatedTime <= availableTime.Minutes &&
                recipe.Ingredients.All(i =>
                    ingredientNames.Contains(i)))
            .OrderBy(r => r.EstimatedTime)
            .ToList();

        return availableRecipes.FirstOrDefault()
               ?? new RecipeSuggestion
               {
                   RecipeName = "Nenhuma receita encontrada",
                   EstimatedTime = 0,
                   Ingredients = []
               };
    }
}