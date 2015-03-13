/*
 * Problem 23. Series of letters
 * Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one.
 * Example:
 * input	                    output
 * aaaaabbbbbcdddeeeedssaa	    abcdedsa
*/
using System;
class SeriesOfLetters
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        string result = input[0].ToString();
        
        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] != result[result.Length - 1])
            {
                result += input[i];
            }
        }

        Console.WriteLine(result);
    }
}

