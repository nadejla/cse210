using System.IO.Enumeration;

public class ActivityManager
{
    // This is the member variable
    private List<Activity> _activities = new List<Activity>();

    // This is the constructor.
    public ActivityManager(int duration)
    {
        _activities.Add(new BreathingActivity("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", duration));
        _activities.Add(new ReflectingActivity("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", duration, ListFromFile("reflectingPrompts.txt"), ListFromFile("reflectingQuestions.txt")));
        _activities.Add(new ListingActivity("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", duration, 0, ListFromFile("listingPrompts.txt")));
        _activities.Add(new GroundingActivity("Grounding Activity", "This activity will help ground yourself during an anxiety or a panic attack.", duration));
    }

    public List<string> ListFromFile(string fileName)
    {
        List<string> list = new List<string>();
        string[] lines = System.IO.File.ReadAllLines(fileName);
        foreach (string line in lines)
        {
            list.Add(line);
        }
        return list;
    }

    public Activity GetActivity(int index)
    {
        return _activities[index];
    }

    public void StartActivity(int index)
    {
        if (index == 0)
        {
            ((BreathingActivity)_activities[index]).Run();
        }
        else if (index == 1)
        {
            ((ReflectingActivity)_activities[index]).Run();
        }
        else if (index == 2)
        {
            ((ListingActivity)_activities[index]).Run();
        }
        else if (index == 3)
        {
            ((GroundingActivity)_activities[index]).Run();
        }
    }
}