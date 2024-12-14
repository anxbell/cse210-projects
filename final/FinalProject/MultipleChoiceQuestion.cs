using System;
using System.Collections.Generic;

public class MultipleChoiceQuestion : Question
{
    private List<string> _options;
    private string _correctAnswer;

    public MultipleChoiceQuestion(
        string text,
        int points,
        List<string> options,
        string correctAnswer
    ) : base(text, points)
    {
        _options = options;
        _correctAnswer = correctAnswer;
    }

    public override void DisplayQuestion()
    {
        Console.WriteLine(GetText());
        for (int i = 0; i < _options.Count; i++)
        {
            Console.WriteLine($"{(char)('a' + i)}) {_options[i]}");
        }
    }

    public override bool CheckAnswer(string answer)
    {
        return answer.Trim().ToLower() == _correctAnswer.ToLower();
    }
}
