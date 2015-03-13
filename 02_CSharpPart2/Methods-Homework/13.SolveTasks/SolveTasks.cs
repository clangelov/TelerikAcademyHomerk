/*
 * Problem 13. Solve tasks
 * Write a program that can solve these tasks:
    Reverses the digits of a number
    Calculates the average of a sequence of integers
    Solves a linear equation a * x + b = 0
    Create appropriate methods.
 * Provide a simple text-based menu for the user to choose which task to solve.
 * Validate the input data:
    The decimal number should be non-negative
    The sequence should not be empty
    a should not be equal to 0
*/
using System;
using System.Linq;
class SolveTasks
{
    static void ReverseNumber()
    {
        Console.Write("Eneter a decimal number: ");
        decimal number = decimal.Parse(Console.ReadLine());

        if (number > 0)
        {
            string operations = Convert.ToString(number);

            char[] arr = operations.Reverse().ToArray();

            Console.WriteLine("Reversed number: {0}", arr);
            Console.WriteLine(new string('-', 30));
        }
        else
        {
            Console.WriteLine("Invalid Input");
            Console.WriteLine(new string('-', 30));
        }
        
    }

    static void FindAverageNumber()
    {
        Console.WriteLine("Enter N numbers separated by space or coma to the Array: ");
        int [] array = Console.ReadLine()
           .Split(new char[] {' ',','}, StringSplitOptions.RemoveEmptyEntries)
           .Select(x => int.Parse(x))
           .ToArray();

        if (array.Length > 0)
        {
            double average = 0;
            average = (double)array.Average();
            Console.WriteLine("The average of all numbers is {0:F2}", average);
            Console.WriteLine(new string('-', 30));
            
        }
        else
        {
            Console.WriteLine("Invalid Input");
            Console.WriteLine(new string('-', 30));
        }
    }

    static void LinearEquation()
    {
        Console.Write("Enter a = ");
        decimal a = decimal.Parse(Console.ReadLine());
        Console.Write("Enter x = ");
        decimal x = decimal.Parse(Console.ReadLine());
        
        decimal b = 0;

        if (a != 0)
        {
            b = 0 - (a * x);
            Console.WriteLine("{0} * {1} + {2} = 0", a, x, b);
            Console.WriteLine(new string('-', 30));
        }
        else
        {
            Console.WriteLine("Invalid Input");
            Console.WriteLine(new string('-', 30));
        }
    }
    static void Main()
    {
        while (true)
	{
        Console.WriteLine("Please choose a type:");
        Console.WriteLine("1 --> Reverses the digits of a number");
        Console.WriteLine("2 --> Calculates the average of a sequence of integers");
        Console.WriteLine("3 --> Solves a linear equation a * x + b = 0");
        Console.WriteLine("4 --> exit");

        Console.Write("User: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(new string('-', 30));

        switch (number)
        {
            case 1: ReverseNumber(); break;
            case 2: FindAverageNumber(); break;
            case 3: LinearEquation(); break;
            case 4: return;

            default: Console.WriteLine("Invalid Input");  
                break;
        }
	}
    }
}

