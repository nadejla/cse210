using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the IA Budget Program!");
        Console.WriteLine("Menu Options");
        Console.WriteLine("  1. View Budget by Index/ActivityCode");
        Console.WriteLine("  2. View Budget by Responsible Party");
        Console.WriteLine("  3. Quit");
        Console.Write("Select a choice from the menu: ");
        MenuManager menuManager = new MenuManager();
        DataManager dataManager = new DataManager();
        string menuResponse = Console.ReadLine();
        while (menuResponse != "3")
        {
            if (menuResponse == "1")
            {
                menuManager.DisplayIndexMenu(dataManager);
            }
            if (menuResponse == "2")
            {
                Console.WriteLine("This will display a list of people.");
            }
            else
            {
                Console.WriteLine("Please enter a valid menu option.");
            }

            Console.Clear();
            Console.WriteLine("Welcome to the IA Budget Program!");
            Console.WriteLine("Menu Options");
            Console.WriteLine("  1. View Budget by Index/ActivityCode");
            Console.WriteLine("  2. View Budget by Responsible Party");
            Console.WriteLine("  3. Quit");
            Console.Write("Select a choice from the menu: ");
            menuResponse = Console.ReadLine(); 
        }
    }

}