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
            transactionManager.ClearTransactionData();
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
                TransactionDisplay transactionDisplay = new TransactionDisplay();
                transactionDisplay.DisplayIndexOverview(dataManager, transactionManager);
                Console.WriteLine("\n1. Select another index or activity code");
                Console.WriteLine("2. Return to main menu");
                Console.Write("\nChoose an option: ");
                choice = Console.ReadLine();
            }      
        }  
    }
    public void DisplayResponsiblePartyMenu(DataManager dataManager, TransactionManager transactionManager)
    {
        Console.Clear();
        Console.WriteLine("\nResponsible Party Menu\n");
        dataManager.DisplayPartyList();
        Console.WriteLine($"\n1. Select Person");
        Console.WriteLine($"2. Return to main menu");
        Console.Write("\nChoose an option: ");
        string choice = Console.ReadLine();
        while (choice != "2")
        { 
            transactionManager.ClearTransactionData();
            Console.Write("\nSelect Responsible or Delegated Party by typing corresponding number: ");
            int partyChoice = int.Parse(Console.ReadLine());
            List<string> funds = dataManager.GetFundsFromParty(partyChoice);
            bool reportAvailable = transactionManager.GetFundsTransactions(funds, dataManager);
            if (!reportAvailable)
            {
                Console.WriteLine("\n1. Select another person");
                Console.WriteLine("2. Return to main menu");
                Console.Write("\nChoose an option: ");
                choice = Console.ReadLine();
            }
            else
            {
                TransactionDisplay transactionDisplay = new TransactionDisplay();
                transactionDisplay.DisplayIndexOverview(dataManager, transactionManager);
                Console.WriteLine("\n1. Select another person");
                Console.WriteLine("2. Return to main menu");
                Console.Write("\nChoose an option: ");
                choice = Console.ReadLine();
            }
        }
        
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