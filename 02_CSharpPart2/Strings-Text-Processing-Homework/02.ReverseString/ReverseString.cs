/*
 * Problem 2. Reverse string
 * Write a program that reads a string, reverses it and prints the result at the console.
 * Example:
 * input	output
 * sample	elpmas
*/
using System;
using System.Linq;
class ReverseString
{
    static void Main()
    {
        Console.Write("Please eneter a string: ");
        string word = Console.ReadLine();        
                
        Console.WriteLine(new string ('-', 30));

        // Transforming the word to char array, which can be Reversed
        char[] reversing = word.ToArray();
        Array.Reverse(reversing);
        
        // From char array to a string
        word = new String (reversing);

        Console.WriteLine("Reversed string = {0}", word);
    }
}

