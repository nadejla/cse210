using System.Security.Permissions;

public class Account
{
    // These are the attributes.
    private string _accountCode;
    private string _accountDescription;

    // This is the constructor.
    public Account(string code, string description)
    {
        _accountCode = code;
        _accountDescription = description;
    }
}