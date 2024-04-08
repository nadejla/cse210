public class TransactionManager
{
    // This is the attribute
    private List<Transaction> _transactions = new List<Transaction>();
    
    // These are the methods
    public void DisplayComprehensiveView()
    {

    }
    public void DisplayIndexOverview(Index index)
    {

    }

    public void DisplayTransactionDetail(Account account)
    {

    }
    public bool GetIndexTransactions(string index)
    {
        string folderPath = @"FGITRND Extracts";
        string fileName = $"{index}FGITRND.csv";
        string filePath = Path.Combine(folderPath, fileName);
        if (File.Exists(filePath))
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            for (int i = 3; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(",");
                string account = parts[0];
                string description = parts[6];
                string fund = parts[8];
                string activity = parts[9];
                string date = parts[11];
                string field = parts[12];
                string amountString = parts[13];
                float amount = float.Parse(amountString);
                if (activity == "")
                {
                    char[] charArray = fund.ToCharArray();
                    charArray[0] = 'W';
                    activity = new string(charArray);
                    Transaction transaction = new Transaction(account, date, description, fund, activity, field, amount);
                    _transactions.Add(transaction);
                }
                else
                {
                    Transaction transaction = new Transaction(account, date, description, fund, activity, field, amount);
                    _transactions.Add(transaction);
                }
            }
            return true;
        }
        else
        {
            Console.WriteLine($"Report not found for {index} at: {filePath}");
            return false;
        }
    }
}