public class SimpleGoal : Goal
{
    // This is the attribute unique to SimpleGoal
    private bool _isComplete;

    // This is the constructor for SimpleGoal
    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {

    }

    // These are the methods for SimpleGoal
    public override void RecordEvent()
    {
        throw new NotImplementedException();
    }

    public override bool IsComplete()
    {
        throw new NotImplementedException();
    }

    public override string GetStringRepresentation()
    {
        throw new NotImplementedException();
    }

}