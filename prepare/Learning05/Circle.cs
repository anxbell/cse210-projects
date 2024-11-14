using System;
class Circle : Shape {
    
    private double _radius;
    public Circle(string color, double radius): base(color) {

        _radius = radius;
    }

    public double GetSide() {
        return _radius;
    }

    public void SetSide() {
        _radius = 1;
    }

    public override double GetArea() {

        return Math.Round((Math.Pow(_radius, 2) * Math.PI),2);
    }
}