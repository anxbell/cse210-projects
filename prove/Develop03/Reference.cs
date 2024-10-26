using System;

class Reference
{
    private int _chapter;
    private string _book;
    private int _startVerse;
    private int _endVerse;

    public Reference()
    {
        _chapter = 1;
        _book = "book";
        _startVerse = 1;
        _endVerse = 1;
    }

    public Reference(string book, int chapter, int startVerse)
    {
        _chapter = chapter;
        _book = book;
        _startVerse = startVerse;
        _endVerse = startVerse; //changed singleverse to using just startverse
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _chapter = chapter;
        _book = book;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }
    //setter
    public string GetReferenceString() //could use override/ternary
    {
        if (_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }
    //display
    public string DisplayReference()
    {
        return GetReferenceString();
    }
}
