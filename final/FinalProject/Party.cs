public abstract class Party
{
    // These are the attributes
    protected string _firstName;
    protected string _lastName;
    protected string _title;
    protected string _department;
    protected List<string> _activityCodes;

    // This is the constructor
    public Party(string firstName, string lastName, string title, string department, List<string> activityCodes)
    {
        _firstName = firstName;
        _lastName = lastName;
        _title = title;
        _department = department;
        _activityCodes = activityCodes;
    }

    public abstract void DisplayParty();
}