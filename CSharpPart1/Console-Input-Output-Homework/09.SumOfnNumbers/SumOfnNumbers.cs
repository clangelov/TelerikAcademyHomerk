using System;

class SumOfnNumbers
{
    /* Problem 9. Sum of n Numbers
     * Write a program that enters a number n and after that enters more n numbers and calculates and prints their sum.
     * Note: You may need to use a for-loop.
    */
    static void Main()
    {
        Console.Write("How many number do you want to sum: ");
        string inputLine = Console.ReadLine();
        int numberN = int.Parse(inputLine);
        
        double currentNum = 0;
        double sum = 0;
        
        for (int i = 0; i < numberN; i++)
        {
            inputLine = Console.ReadLine();
            currentNum = double.Parse(inputLine);
            sum = sum + currentNum;
        }
        
        Console.WriteLine("The sum is: {0}", sum);
    }
}
/* решение с масиви:
 * double sum = 0;
            Console.WriteLine("Sumator of N count numbers\n{0}", new string('-', 30));
            Console.Write("N: ");
            int arraySize = int.Parse(Console.ReadLine());
            Console.WriteLine("------Now enter numbers------");

            double[] numbers = new double[arraySize];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = double.Parse(Console.ReadLine());
                sum += numbers[i];
            }

            Console.WriteLine(new string('-', 30));
            Console.WriteLine(sum);
*/
