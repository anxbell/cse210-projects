using System;
using System.Collections.Generic;

public class Quiz
{
    private List<Question> _questions = new List<Question>();
    private string _topic;

    public Quiz(string topic)
    {
        _topic = topic;
    }

    public string GetTopic()
    {
        return _topic;
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
            // displaying and validating questions dynamically
            question.DisplayQuestion();
            Console.Write("Enter your answer: ");
            string _userAnswer = Console.ReadLine();

            // validation for user answers
            while (string.IsNullOrWhiteSpace(_userAnswer))
            {
                Console.WriteLine("Invalid input. Please provide an answer.");
                Console.Write("Enter your answer: ");
                _userAnswer = Console.ReadLine(); 
                
            }

            if (question.CheckAnswer(_userAnswer))
            {
                score += question.GetPoints();
                Console.WriteLine("Correct! \u2713");
            }
            else
            {
                Console.WriteLine($"Incorrect.");
            }
        }

        return score;
    }

    public int TotalPossiblePoints()
    {
        int totalPoints = 0;
        foreach (var question in _questions)
        {
            totalPoints += question.GetPoints();
        }
        return totalPoints;
    }
}
