using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        //  quizzes
        Quiz generalKnowledgeQuiz = new Quiz("General Knowledge");
        generalKnowledgeQuiz.AddQuestion(
            new MultipleChoiceQuestion(
                "What is the capital of France?",
                10,
                new List<string> { "Madrid", "Paris", "Berlin", "Rome" },
                "b"
            )
        );
        generalKnowledgeQuiz.AddQuestion(
            new TrueFalseQuestion("The Great Wall of China can be seen from space.", 5, false)
        );
        generalKnowledgeQuiz.AddQuestion(
            new ShortAnswerQuestion("Who wrote the play 'Romeo and Juliet'?", 10, "Shakespeare")
        );

        Quiz scienceQuiz = new Quiz("Science");
        scienceQuiz.AddQuestion(
            new MultipleChoiceQuestion(
                "What is the chemical symbol for water?",
                5,
                new List<string> { "H2O", "O2", "CO2", "H2" },
                "a"
            )
        );

        Quiz historyQuiz = new Quiz("History");
        historyQuiz.AddQuestion(
            new MultipleChoiceQuestion(
                "Who was the first President of the United States?",
                5,
                new List<string>
                {
                    "Abraham Lincoln",
                    "George Washington",
                    "Thomas Jefferson",
                    "John Adams"
                },
                "b"
            )
        );

        Leaderboard leaderboard = new Leaderboard();
        leaderboard.LoadFromFile("leaderboard.json");

        Console.WriteLine("Welcome to the Quiz Application! \u263A");

        Console.Write("Enter your name: ");
        string userName = Console.ReadLine();
        User user = new User(userName);

        bool continuePlaying = true;

        while (continuePlaying)
        {
            Console.Clear();
            Console.WriteLine("=== Choose a Quiz Topic ===");
            Console.WriteLine("1. General Knowledge");
            Console.WriteLine("2. Science");
            Console.WriteLine("3. History");
            Console.WriteLine("4. View Leaderboard");
            Console.WriteLine("5. Quit");
            Console.WriteLine("===========================");
            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine();

            Quiz selectedQuiz = null;

            switch (choice)
            {
                case "1":
                    selectedQuiz = generalKnowledgeQuiz;
                    break;
                case "2":
                    selectedQuiz = scienceQuiz;
                    break;
                case "3":
                    selectedQuiz = historyQuiz;
                    break;
                case "4":
                    // display leaderboard and wait for the user
                    Console.Clear();
                    leaderboard.DisplayLeaderboard();
                    Console.WriteLine("\nPress any key to return to the main menu...");
                    Console.ReadKey();
                    continue; // back  main menu
                case "5":
                    continuePlaying = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose a valid option.");
                    continue;
            }

            if (selectedQuiz != null)
            {
                // start the quiz and displaying the score after finishing
                Console.Clear();
                Console.WriteLine($"Starting {selectedQuiz._topic} Quiz:");
                int score = selectedQuiz.StartQuiz();
                user.UpdateScore(score);

                Console.WriteLine(
                    $"\nYour total score for this quiz: {score}/{selectedQuiz.TotalPossiblePoints()} points"
                );
                Console.WriteLine("Well done! \u263A");

                // add user score once
                leaderboard.AddUser(user);
                leaderboard.SaveToFile("leaderboard.json");

                // updated leaderboard
                leaderboard.DisplayLeaderboard();
            }

            if (continuePlaying)
            {
                Console.WriteLine("\nPress any key to go back to the menu...");
                Console.ReadKey();
            }
        }

        Console.WriteLine("Thank you for playing the Quiz Application! \u263A");
    }
}
