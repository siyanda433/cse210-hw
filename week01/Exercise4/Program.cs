using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
       int sum = 0;
int count = 0;
List<int> numbers = new List<int>();

while (true)
{
    Console.Write("Enter a number: ");
    string input = Console.ReadLine();

    if (input == "0")
    {
        break;
    }

    if (int.TryParse(input, out int number))
    {
        sum += number;
        count++;
        numbers.Add(number);
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a number.");
    }
}

if (count > 0)
{
    double average = (double)sum / count;
    int maxNumber = numbers.Max();

    Console.WriteLine($"The sum is: {sum}");
    Console.WriteLine($"The average is: {average}");
    Console.WriteLine($"The largest number is: {maxNumber}");
}
else
{
    Console.WriteLine("No numbers were entered.");
}


    }
}