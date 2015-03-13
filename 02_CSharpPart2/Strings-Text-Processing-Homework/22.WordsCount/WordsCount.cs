/*
 * Problem 22. Words count
 * Write a program that reads a string from the console and lists all different words in the string along with information how many times each word is found.
*/
using System;
using System.Collections.Generic;
using System.Linq;
class WordsCount
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string[] inputText = Console.ReadLine()
            .Split(new char[] { ' ', '.', ',', '!', ':', '?', '-', '"', ';', '(', ')' },
            StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        /*  
            Cheers to the freakin weekend. I drink to that, yeah yeah. Oh, let the Jameson sink in. I drink to that, yeah yeah, Don't let the bastards get ya down! Turn it around with another round. There's a party at the bar!
        */
        
        IDictionary<string, int> words = new Dictionary<string, int>();

        for (int i = 0; i < inputText.Length; i++)
        {
            if (!words.ContainsKey(inputText[i]))
            {
                words.Add(inputText[i], 1);
            }
            else
            {
                words[inputText[i]] += 1;
            }
        }
        
        // Sorting the Dictionary
        var ordered = words.OrderByDescending(x => x.Value);

        if (ordered.Count() == 0)
        {
            Console.WriteLine("Invalid input");
        }
        else
        {
            foreach (var word in ordered)
            {
                Console.WriteLine("[{0}] - {1} times", word.Key, word.Value);
            }
        }
    }
}

