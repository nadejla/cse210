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

    }

    public string GetRandomPrompt()
    {
        return "Prompt";
    }

    public string GetRandomQuestion()
    {
        return "Question";
    }

    public void DisplayPrompt()
    {

    }

    public void DisplayQuestions()
    {
        
    }
}