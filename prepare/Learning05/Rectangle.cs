public class Rectangle : Shape
{
    // Member Variables
    private int _sideA;
    private int _sideB;

    // Constructor
    public Rectangle(string color, int sideA, int sideB) : base(color)
    {
        _sideA = sideA;
        _sideB = sideB;
    }

    public override double GetArea()
    {
        return _sideA * _sideB;
    }
}