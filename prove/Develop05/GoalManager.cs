using System.IO;
using System.IO.Enumeration;

public class GoalManager
{
    // These are the attributes
    private List<Goal> _goals;
    private int _score;

    // This is the constructor
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // These are the methods
    public void Start()
    {
        DisplayPlayerInfo();
        GoalManager goalManager = new GoalManager();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Create New Goal");
        Console.WriteLine("  2. List Goals");
        Console.WriteLine("  3. Save Goals");
        Console.WriteLine("  4. Load Goals");
        Console.WriteLine("  5. Record Event");
        Console.WriteLine("  6. Quit");
        Console.Write("Select a choice from the menu: ");
        string menuResponse = Console.ReadLine();

        while (menuResponse != "6")
        {
            if (menuResponse == "1")
            {
                CreateGoal();
            }
            else if (menuResponse =="2")
            {
                Console.WriteLine("The goals are:");
                ListGoalDetails();
            }
            else if (menuResponse =="3")
            {
                SaveGoals();
            }
            else if (menuResponse =="4")
            {
                LoadGoals();
            }
            else if (menuResponse =="5")
            {
                RecordEvent();
            }
            else
            {
                Console.WriteLine("Please enter a valid menu option.");
            }

        DisplayPlayerInfo();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Create New Goal");
        Console.WriteLine("  2. List Goals");
        Console.WriteLine("  3. Save Goals");
        Console.WriteLine("  4. Load Goals");
        Console.WriteLine("  5. Record Event");
        Console.WriteLine("  6. Quit");
        Console.Write("Select a choice from the menu: ");
        menuResponse = Console.ReadLine();
        }
    }
    public void DisplayPlayerInfo()
    {
        Console.WriteLine();
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine();
    }
    public void ListGoalNames()
    {
        int index = 1;
        foreach (Goal goal in _goals)
        {
            string goalName = goal.GetGoalName();
            Console.WriteLine($"{index}. {goalName}");
            index++;
        }        
    }
    public void ListGoalDetails()
    {
        int index = 1;
        foreach (Goal goal in _goals)
        {
            string goalDetails = goal.GetDetailsString();
            Console.WriteLine($"{index}{goalDetails}");
            index++;
        }
    }
    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string goalType = Console.ReadLine();
        
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is the short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());
        if (goalType == "1")
        {
            SimpleGoal goal = new SimpleGoal(name, description, points);
            _goals.Add(goal);
        }
        else if (goalType == "2")
        {
            EternalGoal goal = new EternalGoal(name, description, points);
            _goals.Add(goal);
        }
        else if (goalType == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
            _goals.Add(goal);
        }
        else
        {
            Console.WriteLine("Please enter a valid goal type.");
        }
    }
    public void RecordEvent()
    {
        Console.WriteLine("The goals are:");
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int goalSelection = int.Parse(Console.ReadLine());
        int points = 0;
        for (int index = 0; index < _goals.Count; index++)
        {
            Goal goal = _goals[index];
            if (goalSelection == index + 1)
            {
                points = goal.RecordEvent();
                if (goal is ChecklistGoal && goal.IsComplete() == true)
                {
                    int bonus = ((ChecklistGoal)goal).GetBonus();
                    points += bonus;
                }
                _score += points;
                break;
            }
        }
        Console.WriteLine($"Congratulations! You have earned {points} points!");
        Console.WriteLine($"You now have {_score} points.");
    }
    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }
    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);
        bool isFirst = true;

        foreach (string line in lines)
        {
            if (isFirst)
            {
                isFirst = false;
                continue;
            }
            // I asked ChatGPT how to skip the first iteration of this loop
            // and it said to use a boolean flag or a counter variable.
            string[] parts = line.Split("|");
            string type = parts[0];
            string[] details = parts[1].Split("~");

            string name = details[0];
            string description = details[1];
            int points = int.Parse(details[2]);

            if (type == "SimpleGoal")
            {
                bool isComplete = bool.Parse(details[3]);
                SimpleGoal goal = new SimpleGoal(name, description, points);
                _goals.Add(goal);
                if (isComplete is true)
                {
                    goal.RecordEvent();
                }
            }
            else if (type == "EternalGoal")
            {
                EternalGoal goal = new EternalGoal(name, description, points);
                _goals.Add(goal);
            }
            else if (type == "ChecklistGoal")
            {
                int amountCompleted = int.Parse(details[5]);
                int target = int.Parse(details[4]);
                int bonus = int.Parse(details[3]);
                ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
                _goals.Add(goal);
                for (int i = amountCompleted; i > 0; i--)
                {
                    goal.RecordEvent();
                }
            }
        }
    }



}