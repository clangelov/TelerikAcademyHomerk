/*
 * Problem 13. Reverse sentence
 * Write a program that reverses the words in given sentence.
 * input	                                output
 * C# is not C++, not PHP and not Delphi!	Delphi not and PHP, not C++ not is C#!
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class ReverseSentence
{
    // I need to fix the location of the punctuation
    static void Main()
    {
        Console.WriteLine("Please enter a sentance:");
        string inputText = Console.ReadLine();
        
        List<char> punctuation = new List<char>();

        for (int i = 0; i < inputText.Length; i++)
        {
            if (inputText[i] == '.' || inputText[i] == ',' || inputText[i] == ':' ||
                inputText[i] == '?' || inputText[i] == '-' || inputText[i] == '!')
            {
                punctuation.Add(inputText[i]);
            }
        }

        punctuation.Reverse();

        string[] sentances = inputText.Split((new char[] {'.', ',', '!', ':', '?', '-'}), StringSplitOptions.RemoveEmptyEntries);

        string[][] words = new string [sentances.Length][];    

        for (int i = 0; i < sentances.Length; i++)
        {
            words[i] = sentances[i].Split((new char[] {' '}), StringSplitOptions.RemoveEmptyEntries);            
        }

        for (int i = 0; i < sentances.Length; i++)
        {
           Array.Reverse(words[i]); 
        }

        string result = string.Empty;
                
        for (int i = sentances.Length-1; i >= 0; i--)
		{
            if (i != 0)
            {
                result += (string.Join(" ", words[i]) + punctuation[i] + " ");
            }
            else
            {
               result += (string.Join(" ", words[i]) + punctuation[i]);
            }            
		}
        
        Console.WriteLine("The reversed sentance is:");
        Console.WriteLine(result);
    }
}

