public class PromptGenerator
{
    // This is the member variable
    public List<string> _prompts = new List<string>();

    // This is the method
    public string GetRandomPrompt()
    {
        
        Random randomPrompt = new Random();
        int index = randomPrompt.Next(_prompts.Count);
        string prompt = _prompts[index];
        return prompt;
    }
}