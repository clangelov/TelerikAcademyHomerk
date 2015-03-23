// Problem 2. IEnumerable extensions
namespace _02.IEnumerableExtensions
{
    using System;
    using System.Collections.Generic;
    class TestIEnumerableExtensions
    {
        static void Main()
        {
            IEnumerable<int> testOne = new List<int> { 2, 3, 5, 7, 13, 30 };
            Console.WriteLine("Test with ints: {0}", string.Join(",", testOne));
            Console.WriteLine("Sum: {0}, Avereage: {1}, Product: {2}, Min: {3}, Max: {4}.\n"
                , testOne.sum(), testOne.average(), testOne.product(), testOne.min(), testOne.max());

            IEnumerable<double> testTwo = new List<double> { 0.5, 2.5, 3.3, 5.7, 6.4, 7.6 };
            Console.WriteLine("Test with ints: {0}", string.Join(",", testTwo));
            Console.WriteLine("Sum: {0:F2}, Avereage: {1:F2}, Product: {2:F2}, Min: {3:F2}, Max: {4:F2}.\n"
                , testTwo.sum(), testTwo.average(), testTwo.product(), testTwo.min(), testTwo.max());

        }
    }
}
