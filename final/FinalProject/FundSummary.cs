public class FundSummary
{
    private float _startingBudget;
    private float _revenueSum;
    private float _expensesSum;
    private float _committedSum;
    private float _remainingBudget;

    public FundSummary(float startingBudget, float revenueSum, float expensesSum, float committedSum, float remainingBudget)
    {
        _startingBudget = startingBudget;
        _revenueSum = revenueSum;
        _expensesSum = expensesSum;
        _committedSum = committedSum;
        _remainingBudget = remainingBudget;
    }

    public void DisplayFundSummary()
    {
        Console.WriteLine($"\nYour starting Budget is: ${_startingBudget.ToString("#,##0.00")}");
        Console.WriteLine($"Your total Revenue is: ${_revenueSum.ToString("#,##0.00")}");
        Console.WriteLine($"Your total Expenses is: ${_expensesSum.ToString("#,##0.00")}");
        Console.WriteLine($"Your Commitments total is: ${_committedSum.ToString("#,##0.00")}");
        Console.WriteLine($"Your remaining Budget is: ${_remainingBudget.ToString("#,##0.00")}\n");
    }
}