using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!\n");
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do? ");
        string menuResponse = Console.ReadLine();
        Journal myJournal = new Journal();
        while (menuResponse != "5")
        {
            if (menuResponse == "1")
            {
                PromptGenerator promptsList = new PromptGenerator();
                string fileName = "prompts.txt";
                string[] lines = System.IO.File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    promptsList._prompts.Add(line);
                }
                string prompt = promptsList.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string promptResponse = Console.ReadLine();
                DateTime currentTime = DateTime.Now;
                string dateText = currentTime.ToString();
                Entry entry = new Entry();
                entry._date = dateText;
                entry._promptText = prompt;
                entry._entryText = promptResponse;
                myJournal.AddEntry(entry);
            }
            else if (menuResponse == "2")
            {
                myJournal.DisplayAll();
            }
            else if (menuResponse == "3")
            {
                Console.WriteLine("What is the file name? (ex. journal.csv)");
                string fileName = Console.ReadLine();
                myJournal.LoadFromFile(fileName);
            }
            else if (menuResponse == "4")
            {
                Console.WriteLine("What is the file name? (ex. journal.csv)");
                string fileName = Console.ReadLine();
                myJournal.SaveToFile(fileName);
            }
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            menuResponse = Console.ReadLine();
        }
    }
}