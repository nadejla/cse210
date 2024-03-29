public class Circle : Shape
{
    // Member Variables
    private int _radius;

    // Constructor
    public Circle(string color, int radius) : base(color)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        return 3.14 * (_radius * _radius);
    }
}