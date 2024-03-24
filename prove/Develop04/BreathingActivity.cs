public class BreathingActivity : Activity
{
    // This is the constructor.
    public BreathingActivity(string name, string description, int duration) : base(name, description, duration)
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
        int cycles = _duration / 10;
        for (int i = cycles; i > 0; i--)
        {
            Console.Write("\n\nBreathe in...");
            ShowCountDown(4);
            Console.Write("\nHold...");
            ShowCountDown(2);
            Console.Write("\nNow Breathe out...");
            ShowCountDown(4);
        }
        DisplayEndingMessage();
    }
}