
/* Problem 3. Compare char arrays
 * Write a program that compares two char arrays lexicographically (letter by letter).
*/
using System;
class CompareCharArrays
{
    static void Main()
    {

        // One string is just an array of chars
        Console.Write("Please enter the first char array as a string: ");
        string firstChar = Console.ReadLine();

        Console.Write("Please enter the second char array as a string: ");
        string secondChar = Console.ReadLine();

        bool areEqual = true;

        if (firstChar.Length == secondChar.Length)
        {
            for (int i = 0; i < firstChar.Length; i++)
            {
                if (firstChar[i] != secondChar[i])
                {
                    areEqual = false;
                    break;
                }                
            }
        }
        else
        {
            areEqual = false;
        }

        Console.WriteLine("The first and the second char arrays are equal: {0}!", areEqual);
    }
}

