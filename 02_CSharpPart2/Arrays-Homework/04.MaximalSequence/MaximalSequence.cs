
/* Problem 4. Maximal sequence
 * Write a program that finds the maximal sequence of equal elements in an array.
 * Input: 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 Result: 2, 2, 2
*/
using System;
class MaximalSequence
{
    static void Main()
    {
        Console.WriteLine("Enter N numbers separated by space or coma: ");
        string input = Console.ReadLine();
        
        // Converting the string to an int array
        string[] numbers = input.Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
        int[] array = new int[numbers.Length];
        
        for (int i = 0; i < numbers.Length; i++)
        {
            array[i] = Convert.ToInt32(numbers[i]);
        }

        int counter = 1;
        int longestSequence = 1;
        int value = 0;
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] == array[i + 1])
            {
                counter++;
                if (longestSequence < counter)
                {
                    longestSequence = counter;
                    value = array[i];
                }
            }
            else
            {
                counter = 1;
            }
        }

        Console.Write("The longest sequence is of {0} elements: ", longestSequence);
        
        for (int i = 0; i < longestSequence; i++)
        {            
            Console.Write(value +" ");
        }
        Console.WriteLine();
                 
    }
}

