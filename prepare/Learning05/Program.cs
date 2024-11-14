using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        Shape shape1 = new Square("blue",2);
        //Console.WriteLine(shape1.GetArea());
        //Console.WriteLine();

        Shape shape2 = new Rectangle("red",8,2);
        //Console.WriteLine(shape2.GetArea());

        Shape shape3 = new Circle("pink",3);
        // Console.WriteLine(shape3.GetArea());

        List<Shape> shapes = new List<Shape>();
        shapes.Add(shape1);
        shapes.Add(shape2);
        shapes.Add(shape3);

        foreach (Shape s in shapes) 
        {
            double area = s.GetArea();
            DisplayShapeInformation(s);
        }
    }

    public static void DisplayShapeInformation(Shape shape)
    {
        double area = shape.GetArea();
        string color = shape.GetColor();
        Console.WriteLine($"The {color} shape has an area of {area}.");
    }


}