using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");
        Console.WriteLine("");
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        List<int> numbers = new List<int>();
        Console.Write("Enter a number: ");
        string inputNumber = Console.ReadLine();
        int number = int.Parse(inputNumber);
        numbers.Add(number);
        int numbersSum = 0;
        int largestNum = 0;
        int smallestNum = 100;
        while (number != 0)
        {
            Console.Write("Enter a number: ");
            inputNumber = Console.ReadLine();
            number = int.Parse(inputNumber);
            if (number != 0)
            {
                numbers.Add(number);
            }
        }
        foreach (int num in numbers)
        {
            numbersSum += num;
            if (num > largestNum)
            {
                largestNum = num;
            }
            if (num < smallestNum && num > 0)
            {
                smallestNum = num;
            }
        }
        int numbersQty = numbers.Count;
        float numbersAvg = ((float)numbersSum) / numbersQty;
        numbers.Sort();
        Console.WriteLine($"The sum is: {numbersSum}");
        Console.WriteLine($"The average is: {numbersAvg}");
        Console.WriteLine($"The largest number is: {largestNum}");
        Console.WriteLine($"The smallest positive number is: {smallestNum}");
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}