/* 
 * Problem 9. Forbidden words
 * We are given a string containing a list of forbidden words and a text containing some of these words.
 * Write a program that replaces the forbidden words with asterisks.
 * 
 * Example text: Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.
 * 
 * Forbidden words: PHP, CLR, Microsoft
 * 
 * The expected result: ********* announced its next generation *** compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***.
*/
using System;
using System.Text.RegularExpressions;
using System.Linq;
class ForbiddenWords
{
    static void Main()
    {
        Console.WriteLine("Please enter a text:");
        string inputText = Console.ReadLine();

        Console.WriteLine(new string('-', 30));

        Console.WriteLine("Enter forbidden words on 1 line separated by space or coma:");
        string[] forbidenWords = Console.ReadLine()
           .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries) // removes ' ' and ','         
           .ToArray(); // puts the elements in the array + using System.Linq;

        Console.WriteLine(new string('-', 30));

        // depending the number of words in string[] forbidenWords i will repeat the following operation 
        for (int i = 0; i < forbidenWords.Length; i++)
		{
            // Regex.Replace search the inputText for the forbidenWords, and replace them with a new string
            // of '*' with the exact smae lenght as the forbidenWord.
            // for this operation: using System.Text.RegularExpressions;
            inputText = Regex.Replace(inputText, forbidenWords[i], new string('*', forbidenWords[i].Length));	 
		}

        Console.WriteLine(new string('-', 30));

        Console.WriteLine("Edited text:");
        Console.WriteLine(inputText);        
    }
}

