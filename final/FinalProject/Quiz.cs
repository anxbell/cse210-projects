using System;
using System.Collections.Generic;

public class Quiz
{
    private List<Question> _questions = new List<Question>();
    public string Topic { get; private set; }  // Added property to store the quiz topic

    // Modified constructor to accept a topic name
    public Quiz(string topic)
    {
        Topic = topic;
    }

    public void AddQuestion(Question question)
    {
        _questions.Add(question);
    }

    public int StartQuiz()
    {
        int score = 0;

        foreach (var question in _questions)
        {
            // Runtime polymorphism: Displaying and validating questions dynamically
            question.DisplayQuestion();
            Console.Write("Enter your answer: ");
            string _userAnswer = Console.ReadLine();

            if (question.CheckAnswer(_userAnswer))
            {
                Console.WriteLine("Correct! \u263A");
                score += question.GetPoints();
            }
            else
            {
                Console.WriteLine("Incorrect.");
            }
            Console.WriteLine();
        }

        return score;
    }

    // Method to calculate the total possible points for the quiz
    public int TotalPossiblePoints()
    {
        int totalPoints = 0;
        foreach (var question in _questions)
        {
            totalPoints += question.GetPoints();  // Accumulate points from each question
        }
        return totalPoints;
    }
}
