using System;
using System.Reflection.Metadata;

public abstract class Question
{
    protected string _text;
    protected int _points;

    public Question(string text, int points)
    {
        _text = text;
        _points = points;
    }

    public abstract void DisplayQuestion();
    public abstract bool CheckAnswer(string answer);

    public int GetPoints() => _points;
}
