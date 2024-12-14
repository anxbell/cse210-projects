using System;
using System.Reflection.Metadata;

public abstract class Question
{
    private string _text;
    private int _points;

    //getters
    public string GetText() => _text;
    public int GetPoints() => _points;

    public Question(string text, int points)
    {
        _text = text;
        _points = points;
    }

    public abstract void DisplayQuestion();
    public abstract bool CheckAnswer(string answer);
}
