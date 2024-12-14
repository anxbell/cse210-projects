using System;

public class ShortAnswerQuestion : Question
{
    private string _correctAnswer;

    public ShortAnswerQuestion(string text, int points, string correctAnswer) : base(text, points)
    {
        _correctAnswer = correctAnswer;
    }

    public override void DisplayQuestion()
    {
        Console.WriteLine(GetText());
    }

    public override bool CheckAnswer(string answer)
    {
        return answer.Trim().ToLower() == _correctAnswer.Trim().ToLower();
    }
}
