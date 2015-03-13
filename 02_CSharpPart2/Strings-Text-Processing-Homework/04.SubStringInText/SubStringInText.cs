/*
 * Problem 4. Sub-string in text
 * Write a program that finds how many times a sub-string is contained in a given text (perform case insensitive search).
 * Example:
 * The target sub-string is "in"
 * The text is as follows: We are living in an yellow submarine. We don't have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.
 * The result is: 9
*/
using System;
class SubStringInText
{
    static void Main()
    {
        Console.WriteLine("Please enter a text:");
        string text = Console.ReadLine();

        text.ToLower();

        Console.WriteLine(new string('-', 50));

        Console.Write("Enter a string, which are you looking for: ");
        string lookinFor = Console.ReadLine();

        lookinFor.ToLower();
        
        int counter = 0;
        int index = text.IndexOf(lookinFor);
        
        while (index != - 1)
        {
            counter++;
            index = text.IndexOf(lookinFor, index + 1);
        }

        Console.WriteLine("The string \"{0}\" can be found {1} times in the text", lookinFor, counter);
    }
}

