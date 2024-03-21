public class Assignment
{
    // These are the member variables.
    protected string _studentName;
    protected string _topic;

    // This is the constructor.
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }
    // This is the method.
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}