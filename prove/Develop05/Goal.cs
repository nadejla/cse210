using System.ComponentModel;

public abstract class Goal
{
    // These are the attributes
    protected string _shortName;
    protected string _description;
    protected int _points;
    
    // This is the constructor
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }
    
    // These are the methods
    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string goalStatus = ". [ ]";
        if (IsComplete() == true)
        {
            goalStatus = ". [X]";
        }
        return $"{goalStatus} {_shortName} ({_description})";
    }

    public abstract string GetStringRepresentation();

    public string GetGoalName()
    {
        return _shortName;
    }
}