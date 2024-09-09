using System;

class NumberGuessingGame
{
    static void Main()
    {
        bool playAgain = true;
        while (playAgain)
        {
            PlayGame();
            playAgain = AskToPlayAgain();
        }
    }

    static void PlayGame()
    {
        Console.WriteLine("Welcome to the Number Guessing Game!");
        Console.WriteLine("Instructions: Guess the number between the specified range. You will be notified if your guess is too high or too low. You have a limited number of attempts. Good luck!");

        int lowerBound = GetBoundary("lower");
        int upperBound = GetBoundary("upper");
        int numberToGuess = NumberGenerator.GenerateNumber(lowerBound, upperBound + 1);
        int userGuess = 0;
        int attempts = 0;
        int maxAttempts = 10;

        while (userGuess != numberToGuess && attempts < maxAttempts)
        {
            Console.Write($"Attempt {attempts + 1}/{maxAttempts}. Enter your guess: ");
            string userInput = Console.ReadLine();
            bool isValidNumber = int.TryParse(userInput, out userGuess);

            if (userInput?.ToLower() == "exit")
            {
                Console.WriteLine("Exiting the game. Thank you for playing!");
                return;
            }

            if (!isValidNumber || userGuess < lowerBound || userGuess > upperBound)
            {
                Console.WriteLine($"Please enter a valid number between {lowerBound} and {upperBound}.");
                continue;
            }
                
            attempts++;
            if (userGuess < numberToGuess)
            {
                Console.WriteLine("Too low! Try again.");
            }
            else if (userGuess > numberToGuess)
            {
                Console.WriteLine("Too high! Try again.");
            }
        }

        if (userGuess == numberToGuess)
        {
            Console.WriteLine($"Congratulations! You guessed the correct number: {numberToGuess} in {attempts} attempts.");
        }
        else
        {
            Console.WriteLine($"You've used all {maxAttempts} attempts. The correct number was: {numberToGuess}. Better luck next time!");
        }
    }

    static bool AskToPlayAgain()
    {
        Console.Write("Do you want to play again? (yes/no): ");
        string answer = Console.ReadLine().ToLower();
        return answer == "yes";
    }

    static int GetBoundary(string boundaryType)
    {
        int boundary;
        while (true)
        {
            Console.Write($"Enter the {boundaryType} boundary for the random number: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out boundary))
            {
                return boundary;
            }
            Console.WriteLine("Please enter a valid number.");
        }
    }
}

static class NumberGenerator
{
    private static Random random = new Random();

    public static int GenerateNumber(int min, int max)
    {
        return random.Next(min, max);
    }
}