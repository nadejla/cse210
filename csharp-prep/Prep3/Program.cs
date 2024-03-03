using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");
        Console.WriteLine("");
        string playAgain = "";
        Console.Write("Would you like to play the number guessing game? ");
        string response = Console.ReadLine();
        playAgain = response.ToLower();

        while (playAgain == "yes")
        {
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 100);
            int guessCount = 1;

            Console.Write("A random number has been generated? What is your guess? ");
            string userGuess = Console.ReadLine();
            int userGuessNumber = int.Parse(userGuess);

            while (userGuessNumber != number)
            {
                if (userGuessNumber > number)
                {
                    Console.WriteLine("Lower");
                }
                else if (userGuessNumber < number)
                {
                    Console.WriteLine("Higher");
                }
                Console.Write("What is your guess? ");
                userGuess = Console.ReadLine();
                userGuessNumber = int.Parse(userGuess);
                guessCount++;
            }

            Console.WriteLine("You guessed it!");
            Console.WriteLine($"It took you {guessCount} try/tries.");
            Console.Write("Would you like to play again? ");
            response = Console.ReadLine();
            playAgain = response.ToLower();
        }
        
    }
}