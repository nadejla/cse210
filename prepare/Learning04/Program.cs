using System;
using System.Linq.Expressions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning04 World!");

        Assignment testAssignment = new Assignment("Nadine Salas", "How to Start a Business");
        Console.WriteLine(testAssignment.GetSummary());
        MathAssignment testMathAssignment = new MathAssignment("Nadine Salas", "Calculating Interest Rates", "7.3", "8-19");
        Console.WriteLine(testMathAssignment.GetSummary());
        Console.WriteLine(testMathAssignment.GetHomeworkList());
        WritingAssignment testWritingAssignment = new WritingAssignment("Nadine Salas", "Business Plan", "Alboom: Personalized Family Keepsakes");
        Console.WriteLine(testWritingAssignment.GetSummary());
        Console.WriteLine(testWritingAssignment.GetWritingInformation());
    }
}