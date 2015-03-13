
/* Problem 12. Index of letters
 * Write a program that creates an array containing all letters from the alphabet (A-Z).
 * Read a word from the console and print the index of each of its letters in the array.
*/
using System;
using System.Linq;

class IndexOfLetters
{
    static void Main()
    {
        // Generating the alphabet. In the ASCII table A == 65 
        char[] alphabet = new char[26];

        for (int i = 0; i < alphabet.Length; i++)
        {
            alphabet[i] = Convert.ToChar(i + 65);
        }
                
        Console.Write("Please enter a word: ");
        string word = Console.ReadLine();
        word = word.ToUpper(); // Makes all leters Upper to match char[] alphabet
               
        for (int i = 0; i < word.Length; i++)
        {
            Console.WriteLine("The letter \"{0}\" is on index {1}", 
                word[i], Array.BinarySearch(alphabet, word[i]));
        }
        
    }
}

