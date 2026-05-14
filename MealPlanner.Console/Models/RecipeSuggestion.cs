namespace MealPlanner.Console.Models;

public class RecipeSuggestion
{
    public string RecipeName { get; set; } = string.Empty;
    public int EstimatedTime { get; set; }
    public List<string> Ingredients { get; set; } = [];
}