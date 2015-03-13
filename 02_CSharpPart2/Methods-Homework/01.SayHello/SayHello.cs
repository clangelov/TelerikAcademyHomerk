/*
 * Problem 1. Say Hello
 * Write a method that asks the user for his name and prints “Hello, <name>”
 * Write a program to test this method.
 * Example:
 * Input: Peter     Output: Hello, Peter! 
*/
using System;
class SayHello
{
    static void PrintHello (string name)
    {
        // removing empty spaces and new lines
        name = name.Trim();
                
        Console.WriteLine("Hello, {0}!", name);
    }
    static void Main()
    {
        Console.Write("Please enter your first name: ");
        string name = Console.ReadLine();

        Console.WriteLine();

        PrintHello(name);

    }
}

