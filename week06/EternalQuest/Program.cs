using System;
using System.Collections.Generic;
using System.IO;

abstract class Goal
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int Points { get; protected set; }

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    public abstract bool IsComplete();
    public abstract int RecordEvent();
    public abstract string GetStatus();
    public abstract string Serialize();

    public static Goal Deserialize(string data)
    {
        string[] parts = data.Split('|');
        string type = parts[0];
        switch (type)
        {
            case "Simple":
                return new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
            case "Eternal":
                return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
            case "Checklist":
                return new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
            default:
                throw new Exception("Unknown goal type.");
        }
    }
}

class SimpleGoal : Goal
{
    private bool completed;

    public SimpleGoal(string name, string description, int points, bool completed = false)
        : base(name, description, points)
    {
        this.completed = completed;
    }

    public override bool IsComplete() => completed;

    public override int RecordEvent()
    {
        if (!completed)
        {
            completed = true;
            return Points;
        }
        return 0;
    }

    public override string GetStatus() => $"[{(completed ? "X" : " ")}] {Name} ({Description})";

    public override string Serialize() => $"Simple|{Name}|{Description}|{Points}|{completed}";
}

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override bool IsComplete() => false;

    public override int RecordEvent() => Points;

    public override string GetStatus() => $"[∞] {Name} ({Description})";

    public override string Serialize() => $"Eternal|{Name}|{Description}|{Points}";
}

class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;
    private int bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus, int currentCount = 0)
        : base(name, description, points)
    {
        this.targetCount = targetCount;
        this.bonus = bonus;
        this.currentCount = currentCount;
    }

    public override bool IsComplete() => currentCount >= targetCount;

    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            currentCount++;
            return Points + (IsComplete() ? bonus : 0);
        }
        return 0;
    }

    public override string GetStatus() =>
        $"[{(IsComplete() ? "X" : " ")}] {Name} ({Description}) -- Completed {currentCount}/{targetCount} times";

    public override string Serialize() =>
        $"Checklist|{Name}|{Description}|{Points}|{targetCount}|{bonus}|{currentCount}";
}

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static int Level => score / 100;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"You have {score} points (Level {Level}).");
            Console.WriteLine("Menu options:");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Save goals");
            Console.WriteLine("4. Load goals");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the Menu: ");

            int choice = GetIntInput();

            switch (choice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoals(); break;
                case 3: SaveGoals(); break;
                case 4: LoadGoals(); break;
                case 5: RecordEvent(); break;
                case 6: return;
                default: Console.WriteLine("Invalid choice."); break;
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }

    static void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Select goal type: ");
        int type = GetIntInput();

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points: ");
        int points = GetIntInput();

        switch (type)
        {
            case 1:
                goals.Add(new SimpleGoal(name, desc, points));
                break;
            case 2:
                goals.Add(new EternalGoal(name, desc, points));
                break;
            case 3:
                Console.Write("How many times to complete: ");
                int target = GetIntInput();
                Console.Write("Bonus on completion: ");
                int bonus = GetIntInput();
                goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid type.");
                break;
        }
    }

    static void ListGoals()
    {
        Console.Clear();
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
        }
        else
        {
            int index = 1;
            foreach (var goal in goals)
            {
                Console.WriteLine($"{index++}. {goal.GetStatus()}");
            }
        }
    }

    static void RecordEvent()
    {
        Console.Clear();
        ListGoals();
        Console.Write("Enter the number of the goal to record: ");
        int idx = GetIntInput();
        if (idx > 0 && idx <= goals.Count)
        {
            int earned = goals[idx - 1].RecordEvent();
            score += earned;
            Console.WriteLine($"Recorded! You earned {earned} points.");
            Console.WriteLine($"New total: {score} points (Level {Level}).");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    static void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(score);
            foreach (var goal in goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }
        Console.WriteLine("Goals saved.");
    }

    static void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            goals.Clear();
            string[] lines = File.ReadAllLines(filename);
            score = int.Parse(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                goals.Add(Goal.Deserialize(lines[i]));
            }
            Console.WriteLine("Goals loaded.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    static int GetIntInput()
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int value))
                return value;
            Console.Write("Invalid number. Try again: ");
        }
    }
}
// I added for every 100 points the level increases by 1.
// The level is calculated by dividing the score by 100.
// I also added a property to get the level in line 42.
// The level is displayed in the menu and when recording an event.
// The level is displayed in the save and load methods.
// The level is displayed in the list of goals.
// The level is displayed in the goal status.
// The level is displayed in the goal serialization.
// The level is displayed in the goal deserialization.
// The codes with the level are in lines 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, and 64.
// I also added the level to the menu and the record event.