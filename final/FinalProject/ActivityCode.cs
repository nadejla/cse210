public class ActivityCode
{
    // These are the attributes.
    private string _activityCode;
    private string _activityDescription;
    private string _index;

    // This is the constructor.
    public ActivityCode(string code, string description, string index)
    {
        _activityCode = code;
        _activityDescription = description;
        _index = index;
    }

    // This is the method

    public void DisplayActivity()
    {
        Console.WriteLine($"  {_activityCode} - {_activityDescription}");
    }

    public string GetActivityCode()
    {
        return _activityCode;
    }

    public string GetIndexCode()
    {
        return _index; 
    }
}