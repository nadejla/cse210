public class GroundingActivity : Activity
{
    // This is the constructor.
    public GroundingActivity(string name, string description, int duration) : base(name, description, duration)
    {
    }

    // This is the method.
    public void Run()
    {
        DisplayStartingMessage();
        if (_duration < 10)
        {
            _duration = 10;
        }
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            // I referred to this resource on tuples, and a similar one on arrays:
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
            var tasks = new (string, int)[]
            {
                ("\nIdentify 5 things you can see. ", 10),
                ("Identify 4 things you can see. ", 8),
                ("Identify 3 things you can see. ", 6),
                ("Identify 2 things you can see. ", 4),
                ("Identify 1 things you can see. ", 2),
            };

            foreach (var (task, duration) in tasks)
            {
                Console.Write(task);
                ShowSpinner(duration);
                Console.WriteLine();

                if (DateTime.Now >= endTime)
                {
                    break;
                }
            }
        }
        DisplayEndingMessage();
    }
}