using System;
using System.Drawing;
using System.Dynamic;

abstract class Shape {

    private string _color;

    public Shape(string color) 
    {

        _color = color;
    }

    public string GetColor() {

        return _color;
    }

    public void SetColor() {

        _color = "white";
    }

    public virtual double GetArea() {
        return 1.0;
    }

}