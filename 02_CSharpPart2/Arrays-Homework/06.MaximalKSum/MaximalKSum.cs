
/* Problem 6. Maximal K sum
 * Write a program that reads two integer numbers N and K and an array of N elements from the console.
 * Find in the array those K elements that have maximal sum.
*/
using System;
using System.Linq;
class MaximalKSum
{
    static void Main()
    {
        
        Console.Write("Please enter the lenght of the Array N = ");
        int lenght = int.Parse(Console.ReadLine());

        Console.Write("Please enter K = ");
        int elements = int.Parse(Console.ReadLine());

        int[] array = new int[lenght];
        for (int i = 0; i < lenght; i++)
        {
            Console.Write("Array {0} = ", array[i]);
            array[i] = int.Parse(Console.ReadLine());
        }
        
        if (array.Length < elements)
        {
            Console.WriteLine("The array has less than {0} elements.", elements);
            return;
        }

        // we need to use using System.Linq; for this solution
        // sorting the Array from the largest int to the smallest one.
        array = array.OrderByDescending(x => x).ToArray();
                
        // Array.Take(elements) takes sertain number of ints from the begging of the sequence 
        // and .Sum() is just making the calculation 
        Console.WriteLine("The sum of the {0} largest numbers is {1}",
            elements, array.Take(elements).Sum());
    }
}

