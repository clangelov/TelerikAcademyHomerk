using System;

class SumOf5Numbers
{
    /* Problem 7. Sum of 5 Numbers
     * Write a program that enters 5 numbers (given in a single line, separated by a space), calculates and prints their sum.
    */
    static void Main()
    {
        Console.WriteLine("Enter 5 numbers separated with space: ");
        string numbers = Console.ReadLine();
        string[] fiveNumbers = numbers.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        double sum = 0;
        double average = 0;

        for (int i = 0; i < fiveNumbers.Length; i++)
        {
            sum += double.Parse(fiveNumbers[i]);
            average = sum / fiveNumbers.Length;
        }

        Console.WriteLine("Sum = {0}", sum);
        Console.WriteLine("Average = {0:F2}", average);
    }
}
/* Едно бих казал по-готино решение
 *  double result = 0;

            Console.WriteLine("Sumator\n{0}",new string('-',20));
            Console.Write("Enter numbers: ");
            string numbers = Console.ReadLine();

            string[] numbsSum = numbers.Split(' ');

            for (int i = 0; i < numbsSum.Length; i++)
            {
                result += double.Parse(numbsSum[i]);
                    
            }
            Console.WriteLine("Sum: {0}",result);
 * 
 * този вариант за четене да се отбелеби също:
 * Console.Write("Enter 5 numbers in a line separated by space and rpess Enter : ");
    string [] numbers = Console.ReadLine().Split(' ');
*/

