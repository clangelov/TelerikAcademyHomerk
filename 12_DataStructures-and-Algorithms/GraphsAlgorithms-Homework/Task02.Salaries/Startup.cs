namespace Task02.Salaries
{
    using System;

    public class Startup
    {
        private static bool[,] adjMatrix;
        private static long[] cache;
        private static int employees;

        public static void Main()
        {
            employees = int.Parse(Console.ReadLine());

            adjMatrix = new bool[employees, employees];

            cache = new long[employees];

            for (int i = 0; i < employees; i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < employees; j++)
                {
                    adjMatrix[i,j] = (line[j] == 'Y');
                }
            }

            long sumOfSalaries = 0;
            for (int i = 0; i < employees; i++)
            {
                sumOfSalaries += FindSalary(i);
            }

            Console.WriteLine(sumOfSalaries);
        }

        private static long FindSalary(int employee)
        {
            if (cache[employee] > 0)
            {
                return cache[employee];
            }

            long salary = 0;
            for (int i = 0; i < employees; i++)
            {
                if (adjMatrix[employee,i])
                {
                    salary += FindSalary(i);
                }
            }

            if (salary == 0)
            {
                salary = 1;
            }

            cache[employee] = salary;
            return salary;
        }
    }
}
