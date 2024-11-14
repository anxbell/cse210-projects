using System;
class Square : Shape {
    
    private double _side;
    public Square(string color, double side): base(color) {

        _side = side;
    }

    public double GetSide() {
        return _side;
    }

    public void SetSide() {
        _side = 1;
    }

    public override double GetArea() {

        return Math.Pow(_side, 3);
    }
}