// Showing Creativity and Exceeding Requirements: Added a "Remove Goal" feature, allowing the user to delete goals from their list.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Goal> goals = new List<Goal>();
        int totalScore = 0;

        while (true)
        {
            Console.WriteLine($"\nYou have {totalScore} points.\n");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Remove Goal");
            Console.WriteLine("7. Quit");
            Console.Write($"\nSelect a choice from the menu: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    GoalManager.CreateGoal(goals);
                    break;
                case 2:
                    GoalManager.ShowGoals(goals);
                    break;
                case 3:
                    FileManager.SaveGoals(goals, totalScore);
                    break;
                case 4:
                    totalScore = FileManager.LoadGoals(goals);
                    break;
                case 5:
                    GoalManager.RecordProgress(goals, ref totalScore);
                    break;
                case 6:
                    GoalManager.RemoveGoal(goals);
                    break;
                case 7:
                    return;
            }
        }
    }
}
