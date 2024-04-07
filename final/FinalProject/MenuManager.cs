public class MenuManager
{
    //There are no attributes or constructors.

    //These are the methods
    public void DisplayIndexMenu(DataManager dataManager)
    {
        Console.Clear();
        Console.WriteLine("Index Menu");
        dataManager.DisplayIndexList();
        Console.Write("\nType an index or account code: ");
        string indexChoice = Console.ReadLine();
        
    }
    public void DisplayResponsiblePartyMenu()
    {
        
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