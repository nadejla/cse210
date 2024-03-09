public class Entry
{
    // These are the member variables
    public string _date;
    public string _promptText;
    public string _entryText;

    // This is the method
    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}\n");
    }
}