/*
 * Problem 13. Count words
 * Write a program that reads a list of words from the file words.txt and finds how many times each of the words is contained in another file test.txt.
 * The result should be written in the file result.txt and the words should be sorted by the number of their occurrences in descending order.
 * Handle all possible exceptions in your methods.
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
class CountWords
{
    //This program is case-sensitive!
    static IDictionary<string, int> FillDictionary(string[] inputLine, 
        List<string> wordsToCount, IDictionary<string, int> wordsCount)
    {
        // adding all words and their count from each single line, which is represented as array
        for (int i = 0; i < wordsToCount.Count; i++)
        {
            for (int j = 0; j < inputLine.Length; j++)
            {
                if (wordsToCount[i] == inputLine[j])
                {
                    if (!wordsCount.ContainsKey(wordsToCount[i]))
                    {
                        // if the word is met for first time
                        // add to dicitnary with value = 1
                        wordsCount.Add(wordsToCount[i], 1);
                    }
                    else
                    {
                        //just increasing the value
                        wordsCount[wordsToCount[i]] += 1;
                    }
                }
            }
        }
        return wordsCount;        
    }
    static void Main()
    {
        string fileInputName = @"..\..\test.txt";
        string adressWordsToCount = @"..\..\words.txt";
        string fileOutputName = @"..\..\result.txt";

        // keeping the words, which will be counted
        List<string> wordsToCount = new List<string>();

        // final result of words and their count
        IDictionary<string, int> wordsCount = new Dictionary<string, int>();

        try
        {
            using (StreamReader readWordsToCount = new StreamReader(adressWordsToCount))
            {
                while (!readWordsToCount.EndOfStream)
                {
                    wordsToCount.Add(readWordsToCount.ReadLine());
                }
            }

            using (StreamReader readText = new StreamReader(fileInputName))
            {
                using (StreamWriter writeResult = new StreamWriter(fileOutputName))
                {
                    while (!readText.EndOfStream)
                    {
                        // making each line of the text to be an array
                        string[] inputLine = readText.ReadLine()
                        .Split(new char[] { ' ', '.',':' }, StringSplitOptions.RemoveEmptyEntries)
                        .Where(x => wordsToCount.Contains(x))
                        .ToArray();

                        wordsCount = FillDictionary(inputLine, wordsToCount, wordsCount);                                 
                    }

                    // ordering the dictionary first by the Value(number of counts)
                    // and then alphabetically
                    var ordered = wordsCount.OrderByDescending(x => x.Value)
                        .ThenBy(x => x.Key);

                    foreach (var word in ordered)
                    {
                        writeResult.WriteLine("[{0}] - {1} times", word.Key, word.Value);
                    }
                }
            }

            Console.WriteLine("The final result can be found at the 13.CountWords main directory");
            Console.WriteLine("as result.txt");
        }
        catch (DirectoryNotFoundException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (FileNotFoundException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (FileLoadException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (EndOfStreamException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (IOException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (ArgumentNullException exception)
        {
            Console.WriteLine(exception.Message);
        }  
    }
}

