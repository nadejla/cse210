public class ReflectingActivity : Activity
{
    // These are the member variables unique to this class.
    private List<string> _prompts;
    private List<string> _questions;

    // This is the constructor
    public ReflectingActivity(string name, string description, int duration, List<string> prompts, List<string> questions) : base(name, description, duration)
    {
        _prompts = prompts;
        _questions = questions;
    }

    // These are the methods
    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("\nConsider the following prompt:\n");
        DisplayPrompt();
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        DisplayQuestions();
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random randomPrompt = new Random();
        int promptIndex = randomPrompt.Next(_prompts.Count);
        string prompt = _prompts[promptIndex];
        return prompt;
    }

    public string GetRandomQuestion()
    {
        Random randomQuestion = new Random();
        int index = randomQuestion.Next(_questions.Count);
        string question = _questions[index];
        return question;
    }

    public void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($" --- {prompt} ---");
    }

    public void DisplayQuestions()
    {
        Console.Clear();
        if (_duration < 10)
        {
            _duration = 10;
        }
        int questionQty = _duration / 10;
        int seconds = _duration / questionQty;
        for (int i = questionQty; i > 0; i--)
        {
            string question = GetRandomQuestion();
            Console.Write($"> {question} ");
            ShowSpinner(seconds);
            Console.WriteLine();
        }
    }
}