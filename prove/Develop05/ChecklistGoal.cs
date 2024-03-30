public class ChecklistGoal : Goal
{
    // These are the attributes unique to ChecklistGoal
    private bool _isComplete;
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    // These are the constructors for ChecklistGoal
    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _isComplete = false;
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    // These are the methods for ChecklistGoal
    public override int RecordEvent()
    {
        _amountCompleted++;
        return _points;
    }

    public override bool IsComplete()
    {
        if (_amountCompleted >= _target)
        {
            return true;
        }
        else
        {
            return false;
        }        
    }

    public override string GetDetailsString()
    {
        string goalStatus = ". [ ]";
        if (IsComplete() == true)
        {
            goalStatus = ". [X]";
        }
        return $"{goalStatus} {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_shortName}~{_description}~{_points}~{_bonus}~{_target}~{_amountCompleted}";
    }

    public int GetBonus()
    {
        return _bonus;
    }

}