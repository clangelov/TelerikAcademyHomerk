/*
 * Problem 14. Word dictionary
 * A dictionary is stored as a sequence of text lines containing words and their explanations.
 * Write a program that enters a word and translates it by using the dictionary.
 * Sample dictionary:
 *  input	        output
 *  NET	            platform for applications from Microsoft
    CLR	            managed execution environment for .NET
    namespace	    hierarchical organization of classes
*/
using System;
using System.Collections.Generic;
class WordDictionary
{
    static void Main()
    {
        IDictionary<string, string> Keywords = new Dictionary<string, string>();
        
        Keywords[".NET"] = "platform for applications from Microsoft";
        Keywords["CLR"] = "managed execution environment for .NET";
        Keywords["namespace"] = "hierarchical organization of classes";        
        Keywords["class"] = "Classes are declared using the keyword class.";
        Keywords["if"] = "The if statement selects a statement for execution based on the value of a Boolean expression";
        Keywords["new"] = "In C#, the new keyword can be used as an operator or as a modifier";
        Keywords["else"] = "The if-else statement selects a statement for execution based on the value of a Boolean expresion";
        Keywords["string"] = "The string type represents a string of Unicode characters";

        Console.WriteLine("Enter a keyword: ");
        string word = Console.ReadLine();

        if (Keywords.ContainsKey(word) == true)
        {
            Console.WriteLine(Keywords[word]);
        }
        else
        {
            Console.WriteLine("{0} Can not be found in the dictionary!", word);   
        }       
    }
}

