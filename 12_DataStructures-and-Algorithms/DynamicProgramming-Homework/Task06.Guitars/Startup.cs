namespace Task06.Guitars
{
    using System;
    using System.Linq;

    // Can be solved with recursion and memoization
    public class Startup
    {
        private const int MIN = 0;
        private static int max;
        private static int[,] dp;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var levels = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int initial = int.Parse(Console.ReadLine());
            max = int.Parse(Console.ReadLine());
            dp = new int[n + 1, max + 1];

            dp[0, initial] = 1;

            for (int i = 1; i <= n; i++)
            {
                int x = levels[i - 1];
                for (int j = 0; j <= max; j++)
                {
                    if (dp[i - 1, j] == 1)
                    {                        
                        if (j + x <= max)
                        {
                            dp[i, j + x] = 1;
                        }

                        if (j - x >= MIN)
                        {
                            dp[i, j - x] = 1;
                        }
                    }
                }
            }

            for (int i = max; i >= 0; i--)
            {
                if (dp[n, i] == 1)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine(-1);
        }
    }
}
