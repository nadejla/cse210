using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("red", 5));
        shapes.Add(new Rectangle("yellow", 4, 6));
        shapes.Add(new Circle("blue", 5));

        foreach (Shape shape in shapes)
        {
            string shapeColor = shape.GetColor();
            double shapeArea = shape.GetArea();
            Console.WriteLine($"Color:{shapeColor}/Area:{shapeArea}");
        }



    }
}