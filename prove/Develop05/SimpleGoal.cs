public class SimpleGoal : Goal
{
    // This is the attribute unique to SimpleGoal
    private bool _isComplete;

    // This is the constructor for SimpleGoal
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // These are the methods for SimpleGoal
    public override int RecordEvent()
    {
        _isComplete = true;
        return _points;
    }

    public override bool IsComplete()
    {
        if (_isComplete == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string GetStringRepresentation()
    {
        string goalStatus = _isComplete.ToString();
        return $"SimpleGoal|{_shortName}~{_description}~{_points}~{goalStatus}";
    }

}