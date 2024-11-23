using System;
using System.Collections.Generic;
using System.IO;

public class FileManager
{
    public static void SaveGoals(List<Goal> goals, int totalScore)
    {
        Console.Write("What is the filename for the goal file: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(totalScore);
            foreach (Goal goal in goals)
            {
                string type = goal.GetType().Name;
                string name = goal.GetName();
                string description = goal.GetDescription();
                int points = goal.GetPoints();

                if (goal is SimpleGoal simpleGoal)
                {
                    writer.WriteLine(
                        $"{type}:{name},{description},{points},{simpleGoal.IsComplete()}"
                    );
                }
                else if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine(
                        $"{type}:{name},{description},{points},{checklistGoal.GetCurrentCount()},{checklistGoal.GetTargetCount()},{checklistGoal.GetBonusPoints()}"
                    );
                }
                else if (goal is EternalGoal)
                {
                    writer.WriteLine($"{type}:{name},{description},{points}");
                }
            }
        }
    }

    public static int LoadGoals(List<Goal> goals)
    {
        goals.Clear();
        int score = 0;

        Console.Write("What is the filename for the goal file: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);

            // if file empty
            if (lines.Length == 0)
                return score;

            score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');

                // errors handle
                if (parts.Length != 2)
                    continue;

                string type = parts[0];
                string[] details = parts[1].Split(',');

                if (details.Length < 3)
                    continue; // added to handle some erros

                string name = details[0];
                string description = details[1];
                int points = int.Parse(details[2]);

                if (type == "SimpleGoal")
                {
                    bool isComplete = details.Length > 3 && bool.Parse(details[3]);
                    SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                    if (isComplete)
                    {
                        simpleGoal.MarkComplete(); // restoring completion status.
                    }
                    goals.Add(simpleGoal);
                }
                else if (type == "ChecklistGoal")
                {
                    if (details.Length < 6)
                        continue; // Insufficient data for ChecklistGoal

                    int currentCount = int.Parse(details[3]);
                    int targetCount = int.Parse(details[4]);
                    int bonusPoints = int.Parse(details[5]);
                    ChecklistGoal checklistGoal = new ChecklistGoal(
                        name,
                        description,
                        points,
                        targetCount,
                        bonusPoints
                    );
                    checklistGoal.SetCurrentCount(currentCount); // Restore current count.
                    goals.Add(checklistGoal);
                }
                else if (type == "EternalGoal")
                {
                    goals.Add(new EternalGoal(name, description, points));
                }
            }
        }

        return score;
    }
}
