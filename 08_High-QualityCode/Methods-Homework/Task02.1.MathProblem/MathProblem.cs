namespace Task02._1.MathProblem
{
    using System;
    using System.Linq;
    using System.Text;

    public class MathProblem
    {
        private const int NumericalSystemBase = 19;

        public static void Main()
        {
            string[] inputInCatSystem = ReadInput();

            int[] numbersInDecimalSystem = FindSumOfNumbersInDecimalSystem(inputInCatSystem);

            int totalSumInDecimal = FindTotalSumInDecimalSystem(numbersInDecimalSystem);

            string totalSumInCatSystem = FindTotalResultInCatSystem(totalSumInDecimal);

            Console.WriteLine(totalSumInCatSystem + " = " + totalSumInDecimal);
        }

        private static string[] ReadInput()
        {
            string[] inputInCatSystem = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            return inputInCatSystem;
        }

        private static int[] FindSumOfNumbersInDecimalSystem(string[] inputInCatSystem)
        {
            int[] sumOfNumbers = new int[inputInCatSystem.Length];
            int power = 1;

            for (int i = 0; i < inputInCatSystem.Length; i++)
            {
                power = 1;
                for (int j = inputInCatSystem[i].Length - 1; j >= 0; j--)
                {
                    // Converts the Ascii code of the letetr to a number in the range 0-19
                    int sign = inputInCatSystem[i][j] - 'a';
                    sumOfNumbers[i] += sign * power;
                    power *= NumericalSystemBase;
                }
            }

            return sumOfNumbers;
        }

        private static int FindTotalSumInDecimalSystem(int[] numbersInDecimalSystem)
        {
            int totalSum = 0;

            for (int i = 0; i < numbersInDecimalSystem.Length; i++)
            {
                totalSum += numbersInDecimalSystem[i];
            }

            return totalSum;
        }

        private static string FindTotalResultInCatSystem(int totalSum)
        {
            StringBuilder resultCat = new StringBuilder();

            while (totalSum > 0)
            {
                int sign = totalSum % NumericalSystemBase;                
                resultCat.Insert(0, Convert.ToChar(sign + 'a'));
                totalSum /= NumericalSystemBase;
            }

            return resultCat.ToString();
        }
    }
}
