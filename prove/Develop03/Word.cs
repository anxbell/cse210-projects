using System;

class Word
{ 
    private string _text; 
    private bool _wordHidden;

    public Word(string text) 
    {
        _text = text;
        _wordHidden = false;
    }

    public void Hide()
    {
        _wordHidden = true;
    }

    public bool IsWordHidden() 
    {
        return _wordHidden;
    }

    public string GetText() 
    {
        string blankSpace = new string('_', _text.Length);

        if (_wordHidden)
        {
            return blankSpace;
        }
        else
        {
            return _text;
        }
    }
}
