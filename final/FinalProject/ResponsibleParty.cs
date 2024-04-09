public class ResponsibleParty : Party
{
    // This is an attribute unique to ResponsibleParty
    private List<string> _indexes;

    // This is the constructor unique to ResponsibleParty
    public ResponsibleParty(string firstName, string lastName, string title, string department, List<string> activityCodes, List<string> indexes) : base(firstName, lastName, title, department, activityCodes)
    {
       _firstName = firstName;
        _lastName = lastName;
        _title = title;
        _department = department;
        _activityCodes = activityCodes;
        _indexes = indexes;
    }

    // This is the method
    public override void DisplayParty()
    {
        Console.WriteLine($"{_firstName} {_lastName}");
    }

    public override List<string> GetFunds()
    {
        List<string> funds = new List<string>();
        foreach (string index in _indexes)
        {
            funds.Add(index);
        }
        foreach (string activity in _activityCodes)
        {
            funds.Add(activity);
        }
        return funds;
    }
}