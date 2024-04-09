public class SummarizedTransaction
{
    private string _account;
    private string _accountDescription;
    private string _field;
    private string _activity;
    private float _total;

    public SummarizedTransaction(string account, string accountDescription, string filed, string activity)
    {
        _account = account;
        _accountDescription = accountDescription;
        _field = filed;
        _activity = activity;
    }

    public SummarizedTransaction(string account, string accountDescription, string filed, string activity, float total)
    {
        _account = account;
        _accountDescription = accountDescription;
        _field = filed;
        _activity = activity;
        _total = total;
    }

    public void DisplaySummarizedTransaction()
    {
        Console.WriteLine($"{_account}-{_accountDescription}-{_field}-{_activity}: ${_total.ToString("#,##0.00")}");
    }

    public string SumTransactionDetailString()
    {
        return $"{_account}-{_field}-{_activity}";
    }

    public void AddToTotal(float amount)
    {
        _total+=amount;
    }

    public string GetAccount()
    {
        return $"{_account} - {_accountDescription}";
    }

    public string GetActivity()
    {
        return _activity;
    }
    public decimal GetAmount()
    {
        decimal total = Convert.ToDecimal(_total);
        return total;
    }

}