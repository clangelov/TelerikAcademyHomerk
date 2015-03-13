/*
 * Problem 5. Sort by string length
 * You are given an array of strings. Write a method that sorts the array by the length of its elements (the number of characters composing them).
*/
using System;
using System.Linq;
class SortByStringLength
{
    static void SortStrings (string [] array)
    {
        // I use array.OrderBy(here you give the parameters) to order the strings by their length and 
        // to put them bach in the array with .ToArray()
        array = array.OrderBy(x => x.Length).ToArray();            

        Console.WriteLine("Sorted strings by their length:");
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
        }
    }
    static void Main()
    {
        Console.WriteLine("Enter N strings separated by space or coma to the Array: ");
        string[] array = Console.ReadLine()
           .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
           .ToArray();

        Console.WriteLine(new string('-', 30));

        // We call the method and in the () is the input data
        SortStrings(array);
    }
}

