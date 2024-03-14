public class Fraction
{
    // These are the member variables
    private int _top;
    private int _bottom;

    // These are the Fraction Constructors
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }
    public Fraction (int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }
    // These are the getters and setters for top and bottom
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }
    // These are the methods to return the respresentations
    public string GetFractionString()
    {
        string fractionString = $"{_top}/{_bottom}";
        return fractionString;
    }

    public double GetDecimalValue()
    {
        // double top = Convert.ToDouble(_top);
        // double bottom = Convert.ToDouble(_bottom);
        return (double)_top / (double)_bottom;
    }
}