using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the program!");
        
        Console.Write("Please enter your name:");
        string name = Console.ReadLine();
        Console.Write("Please enter your favorite number:");
        int number = int.Parse(Console.ReadLine());
        {                          
            Console.WriteLine(name + "," + " " + "the square of your favorite number is" + " " + number * number);              
        }
    }
}