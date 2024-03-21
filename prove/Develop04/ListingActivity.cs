public class ListingActivity : Activity
{
    // These are the member variables unique to this class.
    private int _count;
    private List<string> _prompts;

    // This is the constructor.
    public ListingActivity(string name, string description, int duration, int count, List<string> prompts) : base(name, description, duration)
    {
        _count = count;
        _prompts = prompts;
    }

    // These are the methods.
    public void Run()
    {

    }
    
    public void GetRandomPrompt()
    {

    }

    public List<string> GetListFromUser()
    {
        return _prompts;
    }
}