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
        _count = 0;
        DisplayStartingMessage();
        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        GetRandomPrompt();
        Console.WriteLine("You may begin in: ");
        ShowCountDown(5);
        GetListFromUser();
        Console.Write($"You listed {_count} items!");
        DisplayEndingMessage();
    }
    
    public void GetRandomPrompt()
    {
        Random randomPrompt = new Random();
        int promptIndex = randomPrompt.Next(_prompts.Count);
        string prompt = _prompts[promptIndex];
        Console.WriteLine(prompt);
    }

    public List<string> GetListFromUser()
    {
        List<string> listResponses = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string userResponse = Console.ReadLine();
            listResponses.Add(userResponse);

            _count++;
        }
        return listResponses;
    }
}