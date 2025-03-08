using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 100);

        Console.Write("Guess the number between 1 and 100: ");
        int guess = int.Parse(Console.ReadLine());
        string response = "yes";

        while (response == "yes")
        {
            if (guess < number)
            {
                Console.WriteLine("Higher " + guess);
            }
            else if (guess > number)
            {
                Console.WriteLine("Lower" + guess);
            }
            else
            {
                break;
            }

            Console.Write("Guess again: ");
            guess = int.Parse(Console.ReadLine());
        }

        if (guess == number)
        {
            Console.WriteLine("Congratulations! You guessed the number!");
        }
    }
}