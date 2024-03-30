using System;

class Program
{
    static void Main(string[] args)
    {
        // To exceed requirements I added a rank feature. This feature calculates the max score amount
        // and determines the rank based on the user's score compared to the max score.
        // The max score adds up the points from all goal types and the bonus from the checklist goal.
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}