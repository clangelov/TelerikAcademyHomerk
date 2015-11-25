namespace Task04.SuperSum
{
    using System;
    using System.Linq;

    public class Startup
    {
        private static int[,] map;

        public static void Main()
        {
            var input = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int k = input[0];
            int n = input[1];           

            if (k == 0)
            {
                Console.WriteLine(n);
                return;
            }

            map = new int[k + 1, n];

            for (int i = 0; i < n; i++)
            {
                map[0, i] = i + 1;                
            }

            for (int i = 1; i <= k; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    CreateCell(i, j);
                }
            }

            Console.WriteLine(map[k, n - 1]);
        }

        private static void CreateCell(int a, int b)
         {
            for (int i = 0; i <= b; i++)
            {
                map[a, b] += map[a - 1, i];
            }
        }
    }
}
