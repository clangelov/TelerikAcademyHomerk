
/* Problem 3. Min, Max, Sum and Average of N Numbers
 * Write a program that reads from the console a sequence of n integer numbers and returns the minimal, the maximal number, the sum and the average of all numbers (displayed with 2 digits after the decimal point).
 * The input starts by the number n (alone in a line) followed by n lines, each holding an integer number.
*/

using System;
class MinMaxSumAverage
{
    static void Main()
    {
        Console.Write("How many numbers will be the sequence: ");
        int count = int.Parse(Console.ReadLine());

        int input;
        int sum = 0;
        int maxValue = int.MinValue;
        int minValue = int.MaxValue;

        for (int i = 1; i <= count; i++)
        {
            Console.Write("Enter the {0} number: ", i);
            input = int.Parse(Console.ReadLine());

            sum += input;
            
            if (input > maxValue)
            {
                maxValue = input;
            }
            
            if (input < minValue)
            {
                minValue = input;
            }
        }
        
        double average = (double)sum / count;

        Console.WriteLine("Min = {0}", minValue);
        Console.WriteLine("Max = {0}", maxValue);
        Console.WriteLine("Sum = {0}", sum);
        Console.WriteLine("Avg = {0:F2}", average);
    }
}

