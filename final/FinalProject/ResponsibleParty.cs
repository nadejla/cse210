public class ResponsibleParty : Party
{
    // This is an attribute unique to ResponsibleParty
    private List<string> _indexes;

    // This is the constructor unique to ResponsibleParty
    public ResponsibleParty(string firstName, string lastName, string title, string department, List<string> activityCodes, List<string> indexes) : base(firstName, lastName, title, department, activityCodes)
    {
        _indexes = new List<string>();
    }

    // This is the method
    public void DisplayReponsibleParty()
    {
        
    }
}