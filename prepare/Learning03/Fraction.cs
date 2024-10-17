using System;
using System.IO;

public class Fraction { //Create the Fraction class

    private int _top;
    private int _bottom;


    public Fraction(){ //Constructors 
//methods
        _top = 1;
        _bottom = 1;

    }


    public Fraction(int wholeNumber){

        _top = wholeNumber;
        _bottom = 1;

    }

    public Fraction(int top, int bottom) //setter
    {
        _top = top;
        _bottom = bottom;
    }

    public string GetFractionString(){//getter

        string text = $"{_top}/{_bottom}";
            return text;

    }

    public double GetDecimalValue(){

        return (double)_top / (double)_bottom;

    }

    }