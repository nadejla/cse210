using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");
        Console.WriteLine("");
        Console.Write("What is your grade percentage? ");
        string userGrade = Console.ReadLine();
        float userGradeNumber = float.Parse(userGrade);
        float lastDigit = userGradeNumber % 10;
        string letter = "";
        string sign = "";

        if (userGradeNumber >= 90)
        {
            letter = "A";
        }
        else if (userGradeNumber >= 80)
        {
            letter = "B";
        }
        else if (userGradeNumber >= 70)
        {
            letter = "C";          
        }
        else if (userGradeNumber >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        if (lastDigit >= 7 && !(letter =="A" || letter =="F"))
        {
            sign = "+";
        }
        else if (lastDigit < 3 && letter != "F")
        {
            sign = "-";
        }
        else
        {
            sign ="";
        }

        Console.WriteLine($"Your letter grade is {letter}{sign}");
        if (userGradeNumber >= 70)
        {
            Console.WriteLine("Congratulations! You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}