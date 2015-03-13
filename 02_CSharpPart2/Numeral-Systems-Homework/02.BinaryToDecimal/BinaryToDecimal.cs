/*
 * Problem 2. Binary to decimal
 * Write a program to convert binary numbers to their decimal representation.
*/
using System;
class BinaryToDecimal
{
    static void Main()
    {
        Console.Write("Enter a binary number: ");
        string binary = Console.ReadLine();

        // Supported bases are 2, 8, 10 and 16
        int fromBase = 2;
        int toBase = 10;
        
        String result = Convert.ToString(Convert.ToInt32(binary, fromBase), toBase);

        Console.WriteLine("The result is: {0}", result);
    }
}

