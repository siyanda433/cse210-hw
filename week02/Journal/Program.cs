using System;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
      string _journalEntry = "";

while (true)
{
    Console.WriteLine("Welcome to the Journal Project.");
    Console.WriteLine("Please select one of the following choices: ");
    Console.WriteLine("1. Write");
    Console.WriteLine("2. Display");
    Console.WriteLine("3. Load");
    Console.WriteLine("4. Save");
    Console.WriteLine("5. Quit");

    Console.Write("What would you like to do: ");
    int choice = GetIntInput();

    if (choice == 1)
    {
        var questions = new[]
        {
            "What would you do over again to make your day better?",
            "What was the highlight of your day?",
            "What was the lowlight of your day?",
            "What are you grateful for?",
            "What did you see or do that made you draw closer to God?"
        };

        var random = new Random();
        var question = questions[random.Next(questions.Length)];

        Console.WriteLine(question);
        Console.Write("Please respond: ");
        var response = Console.ReadLine();

        // Add the question and response to the journal entry
        _journalEntry += $"{question}\n{response}\n\n";
    }
    else if (choice == 2)
    {
        Console.WriteLine("Displaying Journal Entries");
        string[] files = System.IO.Directory.GetFiles(".", "*.txt");
        if (files.Length == 0)
        {
            Console.WriteLine("No files found.");
        }
        else
        {
            Console.WriteLine("Available files:");
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {System.IO.Path.GetFileName(files[i])}");
            }
            Console.Write("Enter the number of the file you want to display: ");
            int fileNumber = GetIntInput() - 1;
            if (fileNumber >= 0 && fileNumber < files.Length)
            {
                 DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();
        Console.WriteLine($"Current Date: {dateText}");
                string[] lines = System.IO.File.ReadAllLines(files[fileNumber]);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("Invalid file number.");
            }
        }
    }
    else if (choice == 3)
    {
        Console.WriteLine("Loading Journal Entries");
        
        string[] files = System.IO.Directory.GetFiles(".", "*.txt");
        if (files.Length == 0)
        {
            Console.WriteLine("No files found.");
        }
        else
        {
            Console.WriteLine("Available files:");
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {System.IO.Path.GetFileName(files[i])}");
            }
            Console.Write("Enter the number of the file you want to load: ");
            int fileNumber = GetIntInput() - 1;
            if (fileNumber >= 0 && fileNumber < files.Length)
            {
                DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();
        Console.WriteLine($"Current Date: {dateText}");
                string[] lines = System.IO.File.ReadAllLines(files[fileNumber]);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
                // Load the journal entry from the file
                _journalEntry = string.Join("\n", lines);
            }
            else
            {
                Console.WriteLine("Invalid file number.");
            }
        }
    }
    else if (choice == 4)
    {
        Console.WriteLine("Saving Journal Entries");
        Console.WriteLine("Enter the file name: ");
        string fileName = Console.ReadLine();
        System.IO.File.WriteAllText(fileName, _journalEntry);
        Console.WriteLine("File saved successfully!");
    }
    else if (choice == 5)
    {
        Console.WriteLine("Goodbye!");
        break;
    }
    Console.WriteLine(); // Empty line for better readability
}

// Helper method to get integer input from the user
int GetIntInput()
{
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out int input))
        {
            return input;
        }
        Console.Write("Invalid input. Please enter a number: ");
    }
}

                
    } 
}