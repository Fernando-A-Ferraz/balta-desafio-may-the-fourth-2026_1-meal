using MealPlanner.Console.Models;

namespace MealPlanner.Console.Agents;

public class ScheduleAgent
{
    public AvailableTime ProcessTime(int minutes)
    {
        return new AvailableTime
        {
            Minutes = minutes
        };
    }
}
