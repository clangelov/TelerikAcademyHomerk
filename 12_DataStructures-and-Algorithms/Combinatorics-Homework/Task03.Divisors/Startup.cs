namespace Task03.Divisors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        private static HashSet<int> permutations = new HashSet<int>();
        private static SortedDictionary<int, int> results = new SortedDictionary<int, int>();

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string[] digits = new string[n];

            for (int i = 0; i < n; i++)
            {
                digits[i] = Console.ReadLine();
            }

            GeneratePermutations(digits, 0);            

            foreach (var item in permutations)
            {
                int value = Factors(item);
                if (results.ContainsKey(value))
                {
                    results[value] = item > results[value] ? results[value] : item;
                }
                else
                {
                    results[value] = item;
                }                
            }

            Console.WriteLine(results.First().Value);
        }

        private static int Factors(int num)
        {
            int count = 0;
            for (int i = 2; i <= num; i++)
            {
                if (num % i == 0)
                {
                    count++;
                }
            }

            return count;
        }

        private static void GeneratePermutations<T>(T[] arr, int k)
        {
            if (k >= arr.Length)
            {                
                int key = int.Parse(string.Join(string.Empty, arr));
                permutations.Add(key);
            }
            else
            {
                GeneratePermutations(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutations(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}