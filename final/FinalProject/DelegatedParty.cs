public class DelegatedParty : Party
{
    // This is an attribute unique to DelegatedParty
    private string _supervisor;

    // This is the constructor unique to DelegatedParty
    public DelegatedParty(string firstName, string lastName, string title, string department, List<string> activityCodes, string supervisor) : base(firstName, lastName, title, department, activityCodes)
    {
        _supervisor = supervisor;
    }

    // This is the method
    public void DisplayDelegatedarty()
    {
        
    }
}