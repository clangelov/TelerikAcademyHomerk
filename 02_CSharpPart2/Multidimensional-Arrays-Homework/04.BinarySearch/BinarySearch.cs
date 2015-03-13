/* 
 * Problem 4. Binary search
 * Write a program, that reads from the console an array of N integers and an integer K, sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K.
*/
using System;
using System.Linq;
class BinarySearch
{
    static void Main()
    {
        Console.WriteLine("Enter N numbers separated by space or coma to the Array: ");
        int[] array = Console.ReadLine()
           .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
           .Select(x => int.Parse(x))
           .ToArray();

        Console.Write("Enter the number K: ");
        int number = int.Parse(Console.ReadLine());

        Array.Sort(array);
        int position = Array.BinarySearch(array, number)-1;

        if (position>0)
        {
            Console.Write("The largest number in the array which is ≤ K is ");
            Console.WriteLine(array[position]);    
        }
        else
        {
            Console.WriteLine("K was not found in the array");
        }       
    }
}

