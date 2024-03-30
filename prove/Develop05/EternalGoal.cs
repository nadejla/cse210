public class EternalGoal : Goal
{
    // This is the constructor for EternalGoal
    public EternalGoal(string name, string description, string points) : base(name, description, points)
    {

    }

    // These are the methods for EternalGoal
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