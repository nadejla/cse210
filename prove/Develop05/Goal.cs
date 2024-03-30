using System.ComponentModel;

public abstract class Goal
{
    // These are the attributes
    private string _shortName;
    private string _description;
    private string _points;
    
    // This is the constructor
    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }
    
    // These are the methods
    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        return "string";
    }

    public abstract string GetStringRepresentation();
}