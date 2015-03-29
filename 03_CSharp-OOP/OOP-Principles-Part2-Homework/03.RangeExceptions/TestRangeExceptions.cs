/*
 * Problem 3. Range Exceptions
 * Write a sample application that demonstrates the InvalidRangeException<int> and InvalidRangeException<DateTime> by entering numbers in the range [1..100] and dates in the range [1.1.1980 … 31.12.2013].
*/
namespace _03.RangeExceptions
{
    using System;
    class TestRangeExceptions
    {
        static void Main()
        {
            try
            {
                int min = 1;
                int max = 100;
                int testNumber = int.MinValue;
                if (testNumber < min || testNumber > max)
                {
                    throw new InvalidRangeException<int>(min, max);
                }
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine("Exception caught: {0}", ex.Message);
            }

            try
            {
                DateTime minDate = new DateTime(1980, 1, 1);
                DateTime maxDate = new DateTime(2013, 12, 31);
                DateTime testDate = DateTime.MinValue;
                if (testDate < minDate || testDate > maxDate)
                {
                    throw new InvalidRangeException<DateTime>(minDate, maxDate);
                }
            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine("Exception caught: {0}", ex.Message);
            }
        }
    }
}
