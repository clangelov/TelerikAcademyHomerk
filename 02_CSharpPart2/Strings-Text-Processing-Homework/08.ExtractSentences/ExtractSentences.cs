/*
 * Problem 8. Extract sentences
 * Write a program that extracts from a given text all sentences containing given word.
 * Example:
 * The word is: in
 * The text is: We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.
 * The expected result is: We are living in a yellow submarine. We will move out of it in 5 days.
*/
using System;
class ExtractSentences
{
    static void Main()
    {
        Console.WriteLine("Please enter a text:");
        string inputText = Console.ReadLine();

        Console.WriteLine("Sentences with which word are you looking for:");
        string word = Console.ReadLine();

        string[] sentences = inputText.Split((new char[] {'.'}),StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine("The following sentences are containing {0}:", word);

        for (int i = 0; i < sentences.Length; i++)
        {
            if (sentences[i].Contains(String.Format(" {0} ", word)))
            {
                Console.WriteLine(sentences[i].Trim()+'.');
            }
        }
    }
}

