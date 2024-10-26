using System;

class Word //this class hides words replacing them for underscores based on the length of the word.
{ //responsible for managing its own state (hidden or shown).
    private string _text; //Attributes
    private bool _wordHidden;

    public Word(string text) //Constructor
    {
        _text = text;
        _wordHidden = false;
    }

    public void Hide() //method
    {
        _wordHidden = true;
    }

    public bool IsWordHidden() //Getter Method
    {
        return _wordHidden;
    }

    public string GetText() //method
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
