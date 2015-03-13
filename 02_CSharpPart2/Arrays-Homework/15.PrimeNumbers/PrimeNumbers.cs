
/* Problem 15. Prime numbers
 * Write a program that finds all prime numbers in the range [1...10 000 000]. Use the Sieve of Eratosthenes algorithm.
*/
using System;
using System.Linq;
class PrimeNumbers
{
    static void Main()
    {        
        int[] array = new int[10000001];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i;
        }

        for (int i = 2; i < array.Length; i++)
        {            
            if (array[i] > 1)
            {
                for (int j = i * 2; j < array.Length; j += i)
                    array[j] = 0;
            }
        }

        // Removing all zeros from the array
        array = array.Where(x => x != 0).ToArray();
        
        Console.WriteLine("Prime Numbers:");
        Console.WriteLine(String.Join(", ", array));
    }
}

