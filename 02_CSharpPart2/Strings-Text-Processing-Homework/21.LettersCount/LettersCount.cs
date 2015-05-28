/*
 * Problem 21. Letters count
 * Write a program that reads a string from the console and prints all different letters in the string along with information how many times each letter is found.
*/
using System;
using System.Collections.Generic;
using System.Linq;
class LettersCount
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        // crating a Dictionary with key == char and value == int
        IDictionary<char, int> Letters = new Dictionary<char, int>();

        foreach (char character in input)
        {
            // with Letters.ContainsKey(character) i just add the given char and set the initial value to 1
            if (char.IsLetter(character) == true && !Letters.ContainsKey(character))
            {
                Letters.Add(character, 1);
            }
            // if the char is already in the Dictionary, I just add 1 to its value
            else if (char.IsLetter(character) == true)
            {
                Letters[character] += 1;
            }
        }

        // Sorting the Dictionary
        var ordered = Letters.OrderByDescending(x => x.Value);

        if (ordered.Count() == 0)
        {
            Console.WriteLine("Invalid input");
        }
        else
        {
            foreach (var letter in ordered)
            {
                Console.WriteLine("[{0}] - {1} times", letter.Key, letter.Value);
            }
        }
    }
}

