/*
 * Problem 7. Reverse number
 * Write a method that reverses the digits of given decimal number.
 * Example:
 *  input	output
 *  256	    652
*/
using System;
using System.Collections.Generic;
using System.Linq;
class ReverseNumber
{
    static void ReverseNumber(decimal number)
    {
        string operations = Convert.ToString(number);

        char[] arr = operations.Reverse().ToArray();

        Console.WriteLine("Reversed number: {0}", arr);
    }
    static void Main()
    {
        Console.Write("Eneter a decimal number: ");
        decimal number = decimal.Parse(Console.ReadLine());

        ReverseNumber(number);        
    }
}

