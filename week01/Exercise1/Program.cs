using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your firstname?");
        string firstname = Console.ReadLine();
        Console.WriteLine(firstname);
        
        Console.WriteLine("What is your lastname?");
        string lastname = Console.ReadLine();
        Console.WriteLine(lastname);

        Console.WriteLine("Your name is " + " " + lastname +"," + " " + firstname +  " " + lastname +"!");
    }
}