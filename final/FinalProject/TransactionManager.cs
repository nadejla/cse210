using System.Runtime.InteropServices;
using System.Transactions;

public class TransactionManager
{
    // This is the attribute
    private List<Transaction> _transactions = new List<Transaction>();
    
    private List<Transaction> _activityTransactions = new List<Transaction>();
    private List<SummarizedTransaction> _summedTransactions = new List<SummarizedTransaction>();
    private List<string> _activities = new List<string>();
    private List<string> _accounts = new List<string>();
    
    // These are the methods
    public void ClearTransactionData()
    {
        _transactions.Clear();
        _activityTransactions.Clear();
        _summedTransactions.Clear();
        _activities.Clear();
        _accounts.Clear();
    }

    /// <summary>
    /// Retrieves a list of strings stored in the Transaction Manager to display transactions in a table.
    /// </summary>
    /// <param name="option">Select 1 for columns (activities). Select 2 for rows (accounts).</param>
    /// <returns>A list of strings.</returns>
    public List<string> GetTableStrings(int option)
    {
        List<string> tableStrings = new List<string>();
        if (option == 1)
        {
            tableStrings = _activities;
        }
        else if (option == 2)
        {
            tableStrings = _accounts;
        }
        return tableStrings;
    }
    
    /// <summary>
    /// Retrieves the transactions stored in the Transaction Manager for Display Purposes.
    /// </summary>
    /// <param name="option">Select 1 for index transactions. Select 2 for activity transactions.</param>
    /// <returns>A list of transactions.</returns>
    public List<Transaction> GetTransactions(int option)
    {
        List<Transaction> transactions = new List<Transaction>();
        if (option == 1)
        {
            transactions = _transactions;
        }
        else if (option == 2)
        {
            transactions = _activityTransactions;
        }
        return transactions;
    }
    // public void DisplayIndexOverview(DataManager dataManager)
    // {
    //     DisplayFundSummary();
    //     SummarizeTransactions(dataManager);
    //     TransactionDisplay transactionDisplay = new TransactionDisplay();
    //     transactionDisplay.DisplayDataTable(_activities, _accounts, _summedTransactions, _data);
    // }
    
    public List<SummarizedTransaction> SummarizeTransactions(DataManager dataManager)
    {
        List<String> summedList = new List<String>();
        foreach (Transaction transaction in _transactions)
        {
            string accountCode = transaction.GetAccountCode();
            string accountDescription = dataManager.GetAccountDescription(accountCode);
            if (!_accounts.Contains($"{accountCode} - {accountDescription}"))
            {
                _accounts.Add($"{accountCode} - {accountDescription}");
            }
            string field = transaction.GetField();
            string activity = transaction.GetActivity();
            if (!_activities.Contains(activity))
            {
                _activities.Add(activity);
            }
            float total = transaction.GetAmount();
            string transactionSum = $"{accountCode}-{field}-{activity}";
            SummarizedTransaction summmedTransaction = new SummarizedTransaction(accountCode, accountDescription, field, activity, total);
            if (!summedList.Contains(transactionSum))
            {
                summedList.Add(transactionSum);
                _summedTransactions.Add(summmedTransaction);
            }
            else
            {
                foreach (SummarizedTransaction summarizedTransaction in _summedTransactions)
                {
                    string SumTransactionDetailString = summarizedTransaction.SumTransactionDetailString();
                    if (transactionSum == SumTransactionDetailString)
                    {
                        summarizedTransaction.AddToTotal(total);
                    }
                }
                
            }

        }
        _activities.Sort();
        return _summedTransactions;
    }

    public bool GetFundsTransactions(List<string> fundsList, DataManager dataManager) 
    {
        bool reportAvailable = false;
        foreach (string fund in fundsList)
        {
            string newFund = "";
            char[] charArray = fund.ToCharArray();
            if (charArray[0] == 'W')
            {
                newFund = dataManager.GetIndexFromActivity(fund);
                reportAvailable |= GetActivityTransactions(newFund, fund);
            }
            else if (charArray[0] == '9')
            {
                charArray[0] = 'W';
                newFund = new string(charArray);
                reportAvailable |= GetIndexTransactions(newFund);
            }
        }
        return reportAvailable;
    }

    public bool GetActivityTransactions(string index, string activityCode)
    {
        string folderPath = @"FGITRND Extracts";
        string fileName = $"{index}FGITRND.csv";
        string filePath = Path.Combine(folderPath, fileName);
        if (File.Exists(filePath))
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            for (int i = 3; i < lines.Length; i++)
            {
                string[] parts = SplitCSVLine(lines[i]);
                string account = parts[0];
                string description = parts[6];
                string fund = parts[8];
                string activity = parts[9];
                string date = parts[11];
                string field = parts[12];
                string amountString = parts[13];
                float amount = float.Parse(amountString);
                if (activity == activityCode)
                {
                    Transaction transaction = new Transaction(account, date, description, fund, activity, field, amount);
                    _activityTransactions.Add(transaction);
                }
            }
            Console.WriteLine($"Transactions for {activityCode} added to transactions.");
            return true;
        }
        else
        {
            Console.WriteLine($"Report not found for {activityCode} at: {filePath}");
            return false;
        }
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
                string[] parts = SplitCSVLine(lines[i]);
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
            Console.WriteLine($"Transactions for {index} added to transactions.");
            return true;
        }
        else
        {
            Console.WriteLine($"Report not found for {index} at: {filePath}");
            return false;
        }
    }
    private string[] SplitCSVLine(string line)
    {
         List<string> parts = new List<string>();
        bool inQuotes = false;
        int startIndex = 0;
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == '"')
            {
                inQuotes = !inQuotes;
            }
            else if (line[i] == ',' && !inQuotes)
            {
                string part = line.Substring(startIndex, i - startIndex).Trim('"');
                parts.Add(part);
                startIndex = i + 1;
            }
        }
        string lastPart = line.Substring(startIndex).Trim('"');
        parts.Add(lastPart);
        return parts.ToArray();
    }
}