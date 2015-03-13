
/* Problem 9. Frequent number
 * Write a program that finds the most frequent number in an array.
 * Input: 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 Result: 4 (5 times)
*/
using System;
using System.Linq;
class FrequentNumber
{
    static void Main()
    {
        Console.WriteLine("Enter N numbers separated by space or coma to the Array: ");
        int[] array = Console.ReadLine()
           .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries) // removes ' ' and ','
           .Select(x => int.Parse(x)) // Projects each element of a sequence into a new form
           .ToArray(); // puts the elements in the array
            
        // Sorting the array
        Array.Sort(array);

        // Just counting the amaount of sorted numbers
        int counter = 1;
        int longestCount = 0;
        int number = 0;        
        
        for (int i = 0; i < array.Length-1; i++)
        {
            if (array[i] == array[i +1])
            {
                counter++;
            }
            if (counter > longestCount)
            {
                longestCount = counter;
                number = array[i];
            }              
            else if (array[i] != array[i +1])
	        {
                counter = 1;
	        }

        }
        Console.WriteLine("{0}({1} times)", number, longestCount);    
    }
}

