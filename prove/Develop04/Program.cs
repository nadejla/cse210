using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    // To exceed requirements, I added another activity called Grounding Activity to help a person 
    // ground themselves when having a panic or anxiety attack.
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Start breathing activity");
        Console.WriteLine("  2. Start reflecting activity");
        Console.WriteLine("  3. Start listing activity");
        Console.WriteLine("  4. Start grounding activity");
        Console.WriteLine("  5. Quit");
        Console.Write("Select a choice from the menu: ");
        string menuResponse = Console.ReadLine();
        ActivityManager activityManager = new ActivityManager(0);
        while (menuResponse != "5")
        {
            if (menuResponse == "1")
            {
                activityManager.StartActivity(0);
            }
            else if (menuResponse =="2")
            {
                activityManager.StartActivity(1);
            }
            else if (menuResponse =="3")
            {
                activityManager.StartActivity(2);
            }
            else if (menuResponse =="4")
            {
                activityManager.StartActivity(3);
            }
            else
            {
                Console.WriteLine("Please enter a valid menu option.");
            }

        Console.Clear();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Start breathing activity");
        Console.WriteLine("  2. Start reflecting activity");
        Console.WriteLine("  3. Start listing activity");
        Console.WriteLine("  4. Start grounding activity");
        Console.WriteLine("  5. Quit");
        Console.Write("Select a choice from the menu: ");
        menuResponse = Console.ReadLine();
        }
    }
}