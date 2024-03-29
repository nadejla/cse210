public class Square : Shape
{
    // Member Variables
    private int _side;

    // Constructor
    public Square(string color, int side) : base(color)
    {
        _side = side;
    }

    public override double GetArea()
    {
        return _side * _side;
    }
}