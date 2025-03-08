using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage:");
        string valueFromUser = Console.ReadLine();

        int a = int.Parse(valueFromUser);
        int b = 60;
        int c = 70;
        int d = 80;
        int e = 90;

        if (a >= e)
        {
            Console.WriteLine("You got an A!");
            Console.WriteLine("Congratulations!");
        }
        else if (a >= d)
        {
            Console.WriteLine("You got a B!");
            Console.WriteLine("Congratulations!");
        }
        else if (a >= c)
        {
            Console.WriteLine("You got a C!");
            Console.WriteLine("Congratulations!");
        }
        else if (a >= b)
        {
            Console.WriteLine("You got a D!");
            Console.WriteLine("Congratulations!");
        }
        else if (a >= 0)
        {
            Console.WriteLine("You got an F!");
            Console.WriteLine("Try again next time!");
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
    }
}