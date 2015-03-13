/*
 * Problem 8. Binary short
 * Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).
*/
using System;
class BinaryShort
{
    static void Main()
    {
        Console.Write("Please enter a short number: ");
        Int16 input = short.Parse(Console.ReadLine());

        if (input > short.MaxValue || input < short.MinValue)
        {
            Console.WriteLine("Invalid Input");
            return;
        }

        Console.WriteLine("The binary representation of {0} in the memory is: ", input);
        if (input < 0)
        {
            Console.WriteLine(Convert.ToString(input, 2));    
        }
        else
        {
            Console.WriteLine(Convert.ToString(input, 2).PadLeft(16,'0'));
        }
        
    }
}

