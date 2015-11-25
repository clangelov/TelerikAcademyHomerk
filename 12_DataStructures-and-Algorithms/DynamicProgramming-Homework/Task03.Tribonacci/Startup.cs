namespace Task03.Tribonacci
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            long firstNumber = input[0];
            long secondNumber = input[1];
            long thirdNumber = input[2];
            long n = input[3];

            if (n == 1)
            {
                Console.WriteLine(firstNumber);
                return;
            }
            else if (n == 2)
            {
                Console.WriteLine(secondNumber);
                return;
            }
            else if (n == 3)
            {
                Console.WriteLine(thirdNumber);
                return;
            }
            else
            {
                long result = 0;

                for (int i = 3; i < n; i++)
                {
                    result = firstNumber + secondNumber + thirdNumber;
                    firstNumber = secondNumber;
                    secondNumber = thirdNumber;
                    thirdNumber = result;
                }

                Console.WriteLine(result);
            }            
        }
    }
}
