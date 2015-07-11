/* Task 2. Method PrintStatistics in C#
 * StyleCop settings: disabled: Documentation Rules
*/
namespace Task02.MethodPrintStatistics
{
    using System;
    using System.Linq;

    internal class Statistics
    {
        public void PrintStatisticsToConsole(double[] numbers)
        {
            double maxNumber = this.FindMaxNumber(numbers);
            Console.WriteLine(maxNumber);

            double minNumber = this.FindMinNumber(numbers);
            Console.WriteLine(minNumber);

            double averageNumber = this.FindAverageNumber(numbers);
            Console.WriteLine(averageNumber);
        }

        private double FindMaxNumber(double[] array)
        {
            double max = array.Max();
            return max;
        }

        private double FindMinNumber(double[] array)
        {
            double min = array.Min();
            return min;
        }

        private double FindAverageNumber(double[] array)
        {
            double average = array.Average();
            return average;
        }
    }   
}
