/*
 * Problem 20. Palindromes
 * Write a program that extracts from a given text all palindromes, e.g. ABBA, lamal, exe.
*/
using System;
using System.Linq;
using System.Text;
class Palindromes
{    
    static void Main()
    {
        Console.WriteLine("Please enter some text: ");
        string[] inputText = Console.ReadLine()
            .Split(new char[] { ' ', '.', ',', '!', ':', '?', '-' , '"'}, 
            StringSplitOptions.RemoveEmptyEntries)                      
            .ToArray();
        /*
         * Write a program that extracts from a given text all palindromes, e.g. ABBA, lamal, exe.
         * 
        */

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < inputText.Length; i++)
        {            
            if (inputText[i].Length>1)
            {
                bool symmetric = true;

                for (int j = 0; j < inputText[i].Length/2; j++)
                {
                    if (inputText[i][j] != inputText[i][inputText[i].Length - j - 1])
                    {
                        symmetric = false;
                        break;
                    }
                }
                
                if (symmetric)
                {
                    result.Append(inputText[i]+" ");
                }                
            }
        }        
        
        if (result.Length > 0)
        {
            Console.WriteLine("The Palindromes in the given text are: ");
            Console.WriteLine(result);       
        }
        else
        {
            Console.WriteLine("The are no Palindromes");
        }
             
    }
}

