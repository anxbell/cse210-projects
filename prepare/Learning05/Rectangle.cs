using System;
class Rectangle : Shape {
    
    private double _length;
    private double _width;
    public Rectangle(string color, double length, double width): base(color) {

        _length = length;
        _width = width;
    }

    public double GetLength() {
        return _length;
    }

    public void SetLength() {
        _length = 1;
    }

    public double GetWidth() {
        return _width;
    }

    public void SetWidth() {
        _width = 1;
    }

    public override double GetArea() {

        return _length * _width;
    }
}