public class MathAssignment : Assignment
{
    // These are the member variables.
    private string _textbookSection;
    private string _problems;

    // This is the constructor.
    public MathAssignment(string studentName, string topic, string textbookSection, string problems) : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }
    // This is the method.
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}