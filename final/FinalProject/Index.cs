public class Index
{
    // These are the attributes
    private string _indexCode;
    private string _indexDescription;
    private List<ActivityCode> _activityCodes = new List<ActivityCode>();

    // This is the constructor
    public Index(string code, string description)
    {
        _indexCode = code;
        _indexDescription = description;
    }

    // These are the methods
    public void AddActivityCode(ActivityCode activityCode)
    {
        _activityCodes.Add(activityCode);
    }    

    public string DisplayYIndexCode()
    {
        string wIndexCode = _indexCode;
        char[] charArray = wIndexCode.ToCharArray();
        charArray[0] = 'W';
        wIndexCode = new string(charArray);
        return wIndexCode;
    }
    
    public void DisplayIndex()
    {
        string wIndexCode = DisplayYIndexCode();
        Console.WriteLine($"{wIndexCode} - {_indexDescription}");
    }

    public void DisplayIndexAndActivities()
    {
        string wIndexCode = DisplayYIndexCode();
        Console.WriteLine($"\n{wIndexCode}   - {_indexDescription}");
        for (int i = 1; i < _activityCodes.Count; i++)
        {
            ActivityCode activityCode = _activityCodes[i];
            activityCode.DisplayActivity();
        }
    }

    public string GetIndexCode()
    {
        return _indexCode;
    }
}