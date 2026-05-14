using MealPlanner.Console.Services;

Console.Title = "Meal Planner - May The Fourth 2026";

ExibirCabecalho();

Console.ForegroundColor = ConsoleColor.Cyan;
Console.Write("🍽️ Informe os ingredientes separados por vírgula: ");
Console.ResetColor();

var ingredientInput = Console.ReadLine() ?? string.Empty;

Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("⏱️ Informe quanto tempo livre você tem (minutos): ");
Console.ResetColor();

var timeInput = Console.ReadLine();

if (!int.TryParse(timeInput, out var minutes) || minutes <= 0)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine();
    Console.WriteLine("❌ Tempo inválido. Informe um número maior que zero.");
    Console.ResetColor();
    return;
}

var mealPlannerService = new MealPlannerService();

var suggestion = mealPlannerService.SuggestRecipe(
    ingredientInput,
    minutes);

Console.WriteLine();
Console.WriteLine("======================================");

if (suggestion.EstimatedTime > 0)
{
    Console.ForegroundColor = ConsoleColor.Green;

    Console.WriteLine("✅ Receita encontrada!");
    Console.WriteLine();

    Console.ResetColor();

    Console.WriteLine($"🍽️ Receita: {suggestion.RecipeName}");
    Console.WriteLine($"⏱️ Tempo estimado: {suggestion.EstimatedTime} minutos");

    Console.WriteLine();
    Console.WriteLine("🧂 Ingredientes necessários:");

    foreach (var ingredient in suggestion.Ingredients)
    {
        Console.WriteLine($"• {ingredient}");
    }
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;

    Console.WriteLine("❌ Nenhuma receita encontrada.");
    Console.WriteLine("Tente outros ingredientes ou mais tempo.");

    Console.ResetColor();
}

Console.WriteLine();
Console.WriteLine("Pressione qualquer tecla para sair...");
Console.ReadKey();

static void ExibirCabecalho()
{
    Console.ForegroundColor = ConsoleColor.Magenta;

    Console.WriteLine("======================================");
    Console.WriteLine("  🌌 MAY THE FOURTH 2026");
    Console.WriteLine("     MEAL PLANNER");
    Console.WriteLine("======================================");

    Console.ResetColor();
    Console.WriteLine();
}