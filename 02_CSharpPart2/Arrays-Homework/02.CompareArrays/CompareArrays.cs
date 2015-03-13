
/* Problem 2. Compare arrays
 * Write a program that reads two integer arrays from the console and compares them element by element.
*/
using System;
using System.Linq;
class CompareArrays
{
    static void Main()
    {
        Console.WriteLine("Enter N numbers separated by space or coma to the first Array: ");
        int[] first = Console.ReadLine()
           .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries) // removes ' ' and ','
           .Select(x => int.Parse(x)) // Projects each element of a sequence into a new form
           .ToArray(); // puts the elements in the array

        Console.WriteLine("Enter N numbers separated by space or coma to the second Array: ");
        int[] second = Console.ReadLine()
           .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries) 
           .Select(x => int.Parse(x)) 
           .ToArray(); 

        bool areEqual = true;

        if (first.Length == second.Length)
        {
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    areEqual = false;
                    break;
                }
            }
            Console.WriteLine("The first and the second arrays are equal: {0}!", areEqual);
        }
        else
        {
            Console.WriteLine("The first and the second arrays are equal: {0}!", !areEqual);
        }        
    }
}

