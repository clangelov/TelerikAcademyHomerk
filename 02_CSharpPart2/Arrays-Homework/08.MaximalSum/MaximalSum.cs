
/* Problem 8. Maximal sum
 * Write a program that finds the sequence of maximal sum in given array.
 * Input 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 Output: 2, -1, 6, 4
 * Can you do it with only one loop (with single scan through the elements of the array)?
*/
using System;
using System.Linq;
class MaximalSum
{
    static void Main()
    {
        Console.WriteLine("Enter N numbers separated by space or coma to the Array: ");
        int[] array = Console.ReadLine()
           .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
           .Select(x => int.Parse(x))
           .ToArray();

        int maxSum = int.MinValue;
        int currentSum = 0;
        int startIndex = 0;
        int endIndex = 0;        

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i; j < array.Length; j++)
            {
                currentSum += array[j];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    startIndex = i;
                    endIndex = j;                   
                }                
            }
            currentSum = 0;
        } 
       
        Console.Write("The following sequence gives the maximum Sum of {0}: ", maxSum);
        for (int i = startIndex; i <= endIndex; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}

