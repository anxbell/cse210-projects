using System;

public class Program
{
    static void Main(string[] args)
    {
        // Create quizzes
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

            if (
                !int.TryParse(choice, out int selectedOption)
                || selectedOption < 1
                || selectedOption > 5
            )
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                Console.WriteLine("Press any key to try again...");
                Console.ReadKey();
                continue;
            }

            Quiz selectedQuiz = null;

            switch (selectedOption)
            {
                case 1:
                    selectedQuiz = generalKnowledgeQuiz;
                    break;
                case 2:
                    selectedQuiz = scienceQuiz;
                    break;
                case 3:
                    selectedQuiz = historyQuiz;
                    break;
                case 4:
                    Console.Clear();
                    leaderboard.DisplayLeaderboard();
                    Console.WriteLine("\nPress any key to return to the main menu...");
                    Console.ReadKey();
                    continue;
                case 5:
                    continuePlaying = false;
                    break;
            }

            if (selectedQuiz != null)
            {
                Console.Clear();
                Console.WriteLine($"Starting {selectedQuiz.GetTopic()} Quiz:");
                int score = selectedQuiz.StartQuiz();

                User sessionUser = new User(userName);
                sessionUser.UpdateScore(score);

                Console.WriteLine(
                    $"\nYour total score for this quiz: {score}/{selectedQuiz.TotalPossiblePoints()} points"
                );
                Console.WriteLine("Well done! \u263A");

                leaderboard.AddUser(sessionUser);
                leaderboard.SaveToFile("leaderboard.json");

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
