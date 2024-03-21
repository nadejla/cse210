public class WritingAssignment : Assignment
{
    // This is the member variable.
    private string _title;

    // This is the constructor.
    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {
        _title = title;
    }

    // This is the method.
    public string GetWritingInformation()
    {
        return $"{_title} by {_studentName}";
    }
}