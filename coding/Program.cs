using System;

class NumberGuessingGame
{
    static void Main()
    {
        Random random = new Random();
        int numberToGuess = random.Next(1, 101); // Random number between 1 and 100
        int userGuess = 0;

        Console.WriteLine("Welcome to the Number Guessing Game!");
        Console.WriteLine("I have selected a number between 1 and 100. Can you guess it?");

        while (userGuess != numberToGuess)
        {
            Console.Write("Enter your guess: ");
            string userInput = Console.ReadLine();
            bool isValidNumber = int.TryParse(userInput, out userGuess);

            if (!isValidNumber)
            {
                Console.WriteLine($"{userGuess}Please enter a valid number.");
                continue;
            }

            if (userGuess < numberToGuess)
            {
                Console.WriteLine($"{userGuess} :Too low! Try again.");
            }
            else if (userGuess > numberToGuess)
            {
                Console.WriteLine($"{userGuess} :Too high! Try again.");
            }
            else
            {
                Console.WriteLine($"Congratulations! You guessed the correct number: {numberToGuess}");
            }
        }
    }
}