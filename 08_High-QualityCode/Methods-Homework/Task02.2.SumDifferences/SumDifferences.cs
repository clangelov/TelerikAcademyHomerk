namespace Task02._2.SumDifferences
{
    using System;
    using System.Linq;

    public class SumDifferences
    {
        public static void Main()
        {
            long[] inputArr = ReadInput();

            long absolteSumOdd = FindAbsoluteSumOfAllOddNumbers(inputArr);

            Console.WriteLine(absolteSumOdd);
        }

        private static long[] ReadInput()
        {
            long[] inputArr = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            return inputArr;
        }

        private static long FindAbsoluteSumOfAllOddNumbers(long[] inputArr)
        {
            long absolteSumOdd = 0;

            for (int i = 1; i < inputArr.Length; i++)
            {
                long difference = FindAbosluteDifference(inputArr[i], inputArr[i - 1]);

                if (difference % 2 == 0)
                {
                    continue;
                }
                else
                {
                    absolteSumOdd += difference;
                }
            }

            return absolteSumOdd;
        }

        private static long FindAbosluteDifference(long firstNumber, long secondNumber)
        {
            long larger = 0;
            long smaller = 0;

            if (firstNumber >= secondNumber)
            {
                larger = firstNumber;
                smaller = secondNumber;
            }
            else
            {
                larger = secondNumber;
                smaller = firstNumber;
            }

            long result = larger - smaller;

            return result;
        }
    }
}
