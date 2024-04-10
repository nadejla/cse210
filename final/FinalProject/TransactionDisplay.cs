using System.Data;

public class TransactionDisplay
{
    private Dictionary<string, Dictionary<string, decimal?>> _data = new Dictionary<string, Dictionary<string, decimal?>>();

    // These are the methods
    public void DisplayIndexOverview(DataManager dataManager, TransactionManager transactionManager)
    {
        DisplayBudgetSummary(transactionManager);
        List<SummarizedTransaction> summedTransactions = transactionManager.SummarizeTransactions(dataManager);
        List<string> activities = transactionManager.GetTableStrings(1);
        List<string> accounts = transactionManager.GetTableStrings(2);
        DisplayDataTable(activities, accounts, summedTransactions);
    }
    
   public void DisplayBudgetSummary(TransactionManager transactionManager)
    {
        float startingBudget = 0;
        float revenueSum = 0;
        float expensesSum = 0;
        float committedSum = 0;
        float remainingBudget = 0;
        List<Transaction> transactions = transactionManager.GetTransactions(1);
        List<Transaction> activityTransactions = transactionManager.GetTransactions(2);
        foreach (Transaction aTransaction in activityTransactions)
        {
            if (!transactions.Contains(aTransaction))
            {
                transactions.Add(aTransaction);
            }
        }
        foreach (Transaction transaction in transactions)
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

   public void DisplayDataTable(List<string> columns, List<string> rows, List<SummarizedTransaction> summedTransactions)
    {
        _data.Clear();
        foreach (SummarizedTransaction summarizedTransaction in summedTransactions)
        {
            string account = summarizedTransaction.GetAccount();
            string activity = summarizedTransaction.GetActivity();
            decimal? amount = summarizedTransaction.GetAmount();

            if (!_data.ContainsKey(account))
            {
                _data[account] = new Dictionary<string, decimal?>();
            }
            _data[account][activity] = amount;
        }
        
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add("Account", typeof(string));
        foreach (string column in columns)
        {
            dataTable.Columns.Add(column, typeof(decimal));
        }
        dataTable.Columns.Add("Total", typeof(decimal));

        foreach (var kvp in _data)
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

    
    // // These are methods for an improved program
    // public void DisplayComprehensiveView()
    // {

    // }

    // public void DisplayTransactionDetail(Account account)
    // {

    // }
}