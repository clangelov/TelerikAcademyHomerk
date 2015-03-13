/*
 * Problem 6. String length
 * Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20, the rest of the characters should be filled with *.
 * Print the result string into the console.
*/
using System;
class StringLength
{
    static void Main()
    {
        Console.Write("Please enter a string of maximum 20 characters: ");
        string input = Console.ReadLine();

        if (input.Length>20)
        {
            Console.WriteLine("Invalid Input");
        }
        else
        {
            Console.WriteLine(input.PadRight(20,'*'));
        }
    }
}

