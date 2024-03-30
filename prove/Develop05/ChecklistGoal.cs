public class ChecklistGoal : Goal
{
    // These are the attributes unique to ChecklistGoal
    private bool _isComplete;
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    // These are the constructors for ChecklistGoal
    public ChecklistGoal(string name, string description, string points, int target, int bonus) : base(name, description, points)
    {

    }

    // These are the methods for ChecklistGoal
    public override void RecordEvent()
    {
        throw new NotImplementedException();
    }

    public override bool IsComplete()
    {
        throw new NotImplementedException();
    }

    public override string GetDetailsString()
    {
        return base.GetDetailsString();
    }
    
    public override string GetStringRepresentation()
    {
        throw new NotImplementedException();
    }

}