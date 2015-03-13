
/* Problem 10. Find sum in array
 * Write a program that finds in given array of integers a sequence of given sum S (if present).
 * Example: 
 * Array: 4, 3, 1, 4, 2, 5, 8   Sum: = 11   Result: 4, 2, 5
*/
using System;
using System.Linq;
class FindSumArray
{
    static void Main()
    {
        Console.WriteLine("Enter N numbers separated by space or coma to the Array: ");
        int[] array = Console.ReadLine()
           .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
           .Select(x => int.Parse(x)) 
           .ToArray();

        Console.Write("Enter S: ");
        int sum = int.Parse(Console.ReadLine());

        int arraySum = 0;
        int startIndex = 0;
        int endIndex = 0;
        bool solutionFound = false;

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i; j < array.Length; j++)
            {
                arraySum += array[j];
                if (arraySum == sum)
                {
                    startIndex = i;
                    endIndex = j;
                    solutionFound = true;
                    break;                       
                }
                if (arraySum > sum)
                {
                    arraySum = 0;
                    break;
                }
            }
            if (solutionFound == true)
            {
                break;
            }    
        }        

        if (solutionFound == true)
        {
            Console.Write("The following sequence gives the Sum of{0}: ",sum);
            for (int i = startIndex; i <= endIndex; i++)
            {
                Console.Write(array[i]+" ");
            }
            Console.WriteLine();
            
        }
        else
        {
            Console.WriteLine("No valid Solution!"); 
        }
        
    }
}

