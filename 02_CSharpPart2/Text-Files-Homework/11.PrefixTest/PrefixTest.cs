/*
 * Problem 11. Prefix "test"
 * Write a program that deletes from a text file all words that start with the prefix test.
 * Words contain only the symbols 0…9, a…z, A…Z, _.
*/
using System;
using System.IO;
using System.Linq;
class PrefixTest
{
    static void Main()
    {
        string fileName = @"..\..\news.txt";

        using (StreamReader streamReader = new StreamReader(fileName))
        {
            string currentLine;

            while (!streamReader.EndOfStream)
            {
                currentLine = streamReader.ReadLine();
                //.Where return all elements which meet a given criteria
                //x => !x.StartsWith -> returns all words which do not(!) start with "test"
                string[] separatedWords = currentLine
                    .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(x => !x.StartsWith("test", StringComparison.OrdinalIgnoreCase))
                    .ToArray();

                // Printing the line
                Console.WriteLine(String.Join(" ", separatedWords));
            }
        }      
    }
}

