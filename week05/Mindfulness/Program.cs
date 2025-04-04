using System;
using System.Diagnostics;
using System.Threading;

class MindfulnessProject
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Hello World! This is the Mindfulness Project.");
            Console.WriteLine("Menu options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflection activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");

            Console.Write("Select a choice from the Menu: ");
            int choice = GetIntInput();

            if (choice == 1)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Breathing Activity!");
                Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly.");
                Console.Write("How long, in seconds, would you like for your session? ");
                int duration = GetIntInput();
                Console.WriteLine($"You have chosen a duration of {duration} seconds.");
                Console.WriteLine("Get ready to begin...");
                Thread.Sleep(2000);

                Stopwatch timer = Stopwatch.StartNew();
                while (timer.Elapsed.TotalSeconds < duration)
                {
                    Console.WriteLine("Breathe in... (4 seconds)");
                    Thread.Sleep(4000);
                    if (timer.Elapsed.TotalSeconds >= duration) break;
                    Console.WriteLine("Breathe out... (4 seconds)");
                    Thread.Sleep(4000);
                }

                Console.WriteLine("Well done! You have completed the breathing activity.");
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
            }
            else if (choice == 2)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Reflection Activity!");
                Console.WriteLine("This activity will help you reflect on your day and your thoughts.");
                Console.Write("How long, in seconds, would you like for your session? ");
                int duration = GetIntInput();
                Console.WriteLine($"You have chosen a duration of {duration} seconds.");
                Console.WriteLine("Get ready to begin...");
                Thread.Sleep(2000);

                Console.WriteLine("---Think of a time when you did something really difficult---");
                Console.WriteLine("When you have something in mind, press enter to continue...");
                Console.ReadLine();

                string[] questions = {
                    "What was the highlight of your day?",
                    "What was the lowlight of your day?",
                    "What are you grateful for?",
                    "What did you learn today?",
                    "What are your goals for tomorrow?"
                };

                Stopwatch timer = Stopwatch.StartNew();
                int i = 0;

                while (timer.Elapsed.TotalSeconds < duration && i < questions.Length)
                {
                    Console.WriteLine(questions[i]);
                    Console.Write("Your answer: ");
                    Console.ReadLine();
                    Console.WriteLine("Thank you for sharing.\n");
                    i++;
                }

                Console.WriteLine("You have completed the reflection activity.");
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
            }
            else if (choice == 3)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Listing Activity!");
                Console.WriteLine("This activity will help you list things that you are grateful for.");
                Console.Write("How long, in seconds, would you like for your session? ");
                int duration = GetIntInput();
                Console.WriteLine($"You have chosen a duration of {duration} seconds.");
                Console.WriteLine("Get ready to begin...");
                Thread.Sleep(2000);

                string[] prompts = {
                    "What are you grateful for?",
                    "What are your goals for tomorrow?",
                    "What are your favorite hobbies?",
                    "What are your favorite foods?",
                    "What are your favorite places to visit?"
                };

                Stopwatch timer = Stopwatch.StartNew();
                int i = 0;

                while (timer.Elapsed.TotalSeconds < duration && i < prompts.Length)
                {
                    Console.WriteLine(prompts[i]);
                    Console.Write("Your response: ");
                    Console.ReadLine();
                    Console.WriteLine("Noted!\n");
                    i++;
                }

                Console.WriteLine("You have completed the listing activity.");
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
            }
            else if (choice == 4)
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                Thread.Sleep(1500);
            }
        }
    }

    static int GetIntInput()
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result) && result > 0)
            {
                return result;
            }
            else
            {
                Console.Write("Invalid input. Please enter a positive number: ");
            }
        }
    }
}
