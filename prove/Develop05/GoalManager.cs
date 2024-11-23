using System;
using System.Collections.Generic;

public class GoalManager
{
    public static void CreateGoal(List<Goal> goals)
    {
        Console.WriteLine(
            "The types of Goals are: \n1. Simple Goal \n2. Eternal Goal \n3. Checklist Goal"
        );
        Console.Write("Which type of goal would you like to create? ");
        int type = int.Parse(Console.ReadLine());

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount o points associated with this goal: ");
        int points = int.Parse(Console.ReadLine());

        if (type == 1)
        {
            goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == 2)
        {
            goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == 3)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times: ");
            int bonus = int.Parse(Console.ReadLine());
            goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    public static void RecordProgress(List<Goal> goals, ref int totalScore)
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < goals.Count; i++)
        {
            // only the names of the goals
            Console.WriteLine($"{i + 1}. {goals[i].GetName()}");
        }

        Console.Write("Which goal did you accomplish: ");
        int index = int.Parse(Console.ReadLine());

        int pointsEarned = goals[index - 1].RecordProgress();

        //updating total score
        totalScore += pointsEarned;

        Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        Console.WriteLine($"You now have {totalScore} points.");
    }

    public static void ShowGoals(List<Goal> goals)
    {
        Console.WriteLine("The goals are: ");

        for (int i = 0; i < goals.Count; i++)
        {
            string goalType = goals[i].GetType().Name;

            if (goalType == "ChecklistGoal")
            {
                ChecklistGoal checklistGoal = goals[i] as ChecklistGoal;

                if (checklistGoal != null)
                {
                    // making display the goal progress, name, description, and current/target count
                    Console.WriteLine(
                        $"{i + 1}. {checklistGoal.GetProgress()} {checklistGoal.GetName()} ({checklistGoal.GetDescription()}) -- Currently completed: {checklistGoal.GetCurrentCount()}/{checklistGoal.GetTargetCount()}"
                    );
                }
            }
            else
            {
                // For other types of goals, just display the progress, name, and description
                Console.WriteLine(
                    $"{i + 1}. {goals[i].GetProgress()} {goals[i].GetName()} ({goals[i].GetDescription()})"
                );
            }
        }
    }

    //exceeding requirements
    public static void RemoveGoal(List<Goal> goals)
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetName()}");
        }

        Console.Write("Which goal would you like to remove? ");
        int index = int.Parse(Console.ReadLine());

        if (index >= 1 && index <= goals.Count)
        {
            goals.RemoveAt(index - 1);
            Console.WriteLine("Goal removed successfully.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }
}
