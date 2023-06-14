using System;

class Program
{
    static void Main(string[] args)
    {
        Square square1 = new Square("blue", 5);
        // Console.WriteLine(square1.GetColor());
        // Console.WriteLine(square1.GetArea());

        Rectangle rect1 = new Rectangle("red", 5, 3);
        // Console.WriteLine(rect1.GetColor());
        // Console.WriteLine(rect1.GetArea());

        Circle circle1 = new Circle("orange", 5);
        // Console.WriteLine(circle1.GetColor());
        // Console.WriteLine(circle1.GetArea());

        List<Shape> shapes = new List<Shape>();

        shapes.Add(square1);
        shapes.Add(rect1);
        shapes.Add(circle1);

        foreach (Shape s in shapes)
        {
            Console.WriteLine(s.GetColor());
            Console.WriteLine(s.GetArea());
        }
    }
}