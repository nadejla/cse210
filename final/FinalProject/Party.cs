public class Party
{
    // These are the attributes
    private string _firstName;
    private string _lastName;
    private string _title;
    private string _department;
    private List<string> _activityCodes;

    // This is the constructor
    public Party(string firstName, string lastName, string title, string department, List<string> activityCodes)
    {
        _firstName = firstName;
        _lastName = lastName;
        _title = title;
        _department = department;
        _activityCodes = activityCodes;
    }
}