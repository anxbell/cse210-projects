using System;
using System.Collections.Generic;

public class Quiz
{
    private List<Question> _questions = new List<Question>();
    public string _topic;  

    public Quiz(string topic)
    {
        _topic = topic;
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
