public class MenuManager
{
    //There are no attributes or constructors.

    //These are the methods
    public void DisplayIndexMenu(DataManager dataManager, TransactionManager transactionManager)
    {
        Console.Clear();
        Console.WriteLine("Index Menu");
        dataManager.DisplayIndexList();
        Console.WriteLine("\n1. Select index or activity code");
        Console.WriteLine("2. Return to main menu");
        Console.Write("\nChoose an option: ");
        string choice = Console.ReadLine();
        while (choice != "2")
        {
            Console.Write("\nType an index or activity code: ");
            string userChoice = Console.ReadLine();
            string upperChoice = userChoice.ToUpper();
            string indexChoice = dataManager.GetIndexFromActivity(upperChoice);
            bool reportAvailable = transactionManager.GetIndexTransactions(indexChoice);
            if (!reportAvailable)
            {
                Console.WriteLine("\n1. Select another index or activity code");
                Console.WriteLine("2. Return to main menu");
                Console.Write("\nChoose an option: ");
                choice = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Report will show here.");
                Console.WriteLine("\n1. Select another index or activity code");
                Console.WriteLine("2. Return to main menu");
                Console.Write("\nChoose an option: ");
                choice = Console.ReadLine();
            }
            
        }
        

        
    }
    public void DisplayResponsiblePartyMenu(DataManager dataManager)
    {
        Console.Clear();
        Console.WriteLine("Responsible Party Menu");
        dataManager.DisplayPartyList();
        Console.Write("\nType the name of a Responsible or Delegated Party: ");
        string partyChoice = Console.ReadLine();
    }
    public void ExportTransactions()
    {
        
    }
    public void ExportIndexSummary()
    {
        
    }
    public void ExportOverview()
    {
        
    }
}