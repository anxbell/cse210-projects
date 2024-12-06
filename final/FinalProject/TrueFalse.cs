using System;

public class TrueFalseQuestion : Question
{
    private bool _correctAnswer;

    public TrueFalseQuestion(string text, int points, bool correctAnswer) : base(text, points)
    {
        _correctAnswer = correctAnswer;
    }

    public override void DisplayQuestion()
    {
        Console.WriteLine(_text + " (true/false)");
    }

    public override bool CheckAnswer(string answer)
    {
        return bool.TryParse(answer, out bool parsedAnswer) && parsedAnswer == _correctAnswer;
    }
}
