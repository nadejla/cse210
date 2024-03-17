using System;

class Program
{
    // To exceed requirements, I randomly selected to hide only words that weren't already hidden.
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop03 World!");

        string userInput = "";
        string scriptureBook = "2 Nephi";
        int scriptureChapter = 2;
        int scriptureVerse = 25;
        int scriptureEndVerse = 0;
        string scriptureText = "Adam fell that men might be; and men are, that they might have joy.";
        
        Reference reference;
        if (scriptureEndVerse == 0)
        {
            reference = new Reference (scriptureBook, scriptureChapter, scriptureVerse);
        }
        else
        {
            reference = new Reference (scriptureBook, scriptureChapter, scriptureVerse, scriptureEndVerse);
        }
        Scripture scripture = new Scripture (reference, scriptureText);

        Console.Clear();
        while (!scripture.IsCompletelyHidden() && userInput.ToLower() != "quit")
        {
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");
        userInput = Console.ReadLine();
        scripture.HideRandomWords(3);
        Console.Clear();
        }
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");
        userInput = Console.ReadLine();
    }
}