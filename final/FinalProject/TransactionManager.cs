using System.Data;

public class TransactionManager
{
    // This is the attribute
    private List<Transaction> _transactions = new List<Transaction>();
    
    private List<Transaction> _activityTransactions = new List<Transaction>();
    private List<SummarizedTransaction> _summedTransactions = new List<SummarizedTransaction>();
    private List<string> _activities = new List<string>();
    private List<string> _accounts = new List<string>();
    private Dictionary<string, Dictionary<string, decimal?>> data = new Dictionary<string, Dictionary<string, decimal?>>();
    
    // These are the methods
    public void DisplayComprehensiveView()
    {

    }
    public void DisplayIndexOverview(DataManager dataManager)
    {
        DisplayFundSummary();
        SummarizeTransactions(dataManager);
        DisplayDataTable(_activities, _accounts);
    }

    public void DisplayTransactionDetail(Account account)
    {

    }
    
    public void DisplayDataTable(List<string> columns, List<string> rows)
    {
        data.Clear();
        foreach (SummarizedTransaction summarizedTransaction in _summedTransactions)
        {
            string account = summarizedTransaction.GetAccount();
            string activity = summarizedTransaction.GetActivity();
            decimal? amount = summarizedTransaction.GetAmount();

            if (!data.ContainsKey(account))
            {
                data[account] = new Dictionary<string, decimal?>();
            }
            data[account][activity] = amount;
        }
        
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add("Account", typeof(string));
        foreach (string column in columns)
        {
            dataTable.Columns.Add(column, typeof(decimal));
        }
        dataTable.Columns.Add("Total", typeof(decimal));

        foreach (var kvp in data)
        {
            DataRow row = dataTable.NewRow();
            row["Account"] = kvp.Key;
            foreach (string column in columns)
            {
                if (kvp.Value.ContainsKey(column))
                {
                    row[column] = kvp.Value[column];
                }
                else
                {
                    row[column] = DBNull.Value;
                }
                
            }
            row["Total"] = kvp.Value.Values.Sum();
            dataTable.Rows.Add(row);
        }
        Console.WriteLine($"| {"Account",-45} | {string.Join(" | ", columns.Select(c => c.PadLeft(10)))} | Total{" |"}");

        // Display separator line
        Console.WriteLine(new string('-', 5 + 12 * columns.Count + 8));

        // Display data rows
        foreach (DataRow dataRow in dataTable.Rows)
        {
            Console.Write($"| {dataRow["Account"],-45} ");
            foreach (string column in columns)
            {
                Console.Write($"| {FormatNullableDecimal(dataRow[column]).PadLeft(10)} ");
            }
            Console.WriteLine($"| {FormatNullableDecimal(dataRow["Total"]).PadLeft(10)} |");
        }
    }

    static string FormatNullableDecimal(object value)
    {
        if (value == DBNull.Value || value is null)
        {
            return "-";
        }
        else
        {
        return $"{(decimal)value:C}";
        }
    }
    
    public void SummarizeTransactions(DataManager dataManager)
    {
        _summedTransactions.Clear();
        _accounts.Clear();
        _activities.Clear();
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
    }

    public void DisplayFundSummary()
    {
        float startingBudget = 0;
        float revenueSum = 0;
        float expensesSum = 0;
        float committedSum = 0;
        float remainingBudget = 0;
        foreach (Transaction aTransaction in _activityTransactions)
        {
            if (!_transactions.Contains(aTransaction))
            {
                _transactions.Add(aTransaction);
            }
        }
        foreach (Transaction transaction in _transactions)
        {
            string field = transaction.GetField();
            float amount = transaction.GetAmount();
            int accountInt = transaction.GetAccountInt();
            if (field == "OBD" || field == "ABD")
            {
                startingBudget+=amount;
            }
            else if (field == "ENC" || field == "RSV")
            {
                committedSum+=amount;
            }
            else
            {
                if (accountInt > 599999)
                {
                    expensesSum+=amount;
                }
                else
                {
                    revenueSum+=amount;
                }
            }
        }
        remainingBudget = startingBudget + revenueSum - expensesSum - committedSum;
        FundSummary fundSummary = new FundSummary(startingBudget, revenueSum, expensesSum, committedSum, remainingBudget);
        fundSummary.DisplayFundSummary();
    }

    public bool GetFundsTransactions(List<string> fundsList, DataManager dataManager) 
    {
        _transactions.Clear();
        _activityTransactions.Clear();
        bool reportAvailable = false;
        foreach (string fund in fundsList)
        {
            string newFund = "";
            char[] charArray = fund.ToCharArray();
            if (charArray[0] == 'W')
            {
                newFund = dataManager.GetIndexFromActivity(fund);
                reportAvailable = GetActivityTransactions(newFund, fund);
            }
            else if (charArray[0] == '9')
            {
                charArray[0] = 'W';
                newFund = new string(charArray);
                reportAvailable = GetIndexTransactions(newFund);
            }
            if (reportAvailable)
            {
                return true;
            }
        }
        return false;
    }

    public bool GetActivityTransactions(string index, string activityCode)
    {
        _activityTransactions.Clear();
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
        _transactions.Clear();
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