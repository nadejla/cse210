public class Transaction
{
    // These are the attributes.
    private string _account;
    private string _date;
    private string _description;
    private string _fund;
    private string _activity;
    private string _field;
    private float _amount;

    // This is the constructor.
    public Transaction(string account, string date, string description, string fund, string activity, string field, float amount)
    {
        _account = account;
        _date = date;
        _description = description;
        _fund = fund;
        _activity = activity;
        _field = field;
        _amount = amount;
    }

    // This is a method.
    public string TransactionDetailString()
    {
        return "";
    }
}