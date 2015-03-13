/*
 * Problem 10. Unicode characters
 * Write a program that converts a string to a sequence of C# Unicode character literals.
 * Use format strings.
*/
using System;
using System.Text;

class UnicodeCharacters
{
    static void Main()
    {
        Console.Write("Enter a word: ");
        string inputWord = Console.ReadLine();

        StringBuilder result = new StringBuilder();              
        
        foreach (char letter in inputWord)
        {
            //  (int)letter -> gives the number of the letter from the ASCII Table
            // "\\u{0:X4}" X makes the number in hexadeciaml numericla system and 4 gives the length of the number (something like .Padleft)
            result.Append(String.Format("\\u{0:X4}", (int)letter));
        }

        Console.WriteLine("Output is:");
        Console.WriteLine(result);
    }
}

