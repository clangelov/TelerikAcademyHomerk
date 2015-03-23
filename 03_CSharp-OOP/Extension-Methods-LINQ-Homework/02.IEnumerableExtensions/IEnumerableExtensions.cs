/*
 * Problem 2. IEnumerable extensions
 * Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.
*/
namespace _02.IEnumerableExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public static class IEnumerableExtensions
    {
        // function Sum of T
        public static T sum<T>(this IEnumerable<T> input)
        {
            T sum = default(T);

            foreach (var number in input)
            {
                sum += (dynamic)number;
            }

            return sum;
        }

        // function Product if T
        public static T product<T>(this IEnumerable<T> input)
        {
            T product = (dynamic)1;

            foreach (var number in input)
            {
                product *= (dynamic)number;
            }

            return product;
        }

        // function Average of T
        public static T average<T>(this IEnumerable<T> input)
        {
            T average = default(T);

            T sum = input.sum(); // using the function sum to do some of the job

            int count = 0;
            foreach (var number in input)
            {
                count++;
            }

            return average = sum / (dynamic)count;
        }

        // function min of T
        public static T min<T>(this IEnumerable<T> input)
            where T : IComparable // without using it, it's inposible to compare the different values
        {
            dynamic min = input.ElementAt(0);
            
            foreach (var number in input)
            {
                if (number.CompareTo(min) < 0)
                {
                    min = number;
                }
            }

            return min;
        }

        // function max of T
        public static T max<T>(this IEnumerable<T> input)
            where T : IComparable
        {
            dynamic max = input.ElementAt(0);

            foreach (var number in input)
            {
                if (number.CompareTo(max) > 0)
                {
                    max = number;
                }
            }

            return max;
        }
    }
}
