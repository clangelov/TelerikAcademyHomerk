namespace Task05.Brackets
{
    using System;

    public class Startup
    {
        private static long[,] f;
        private static char[] brack;

        public static void Main()
        {
            string input = Console.ReadLine();

            int n = input.Length;

            long num1 = 0;
            long num2 = 0;

            brack = new char[n + 1];

            f = new long[n + 1, n + 1];

            for (int i = 1; i <= n; i++)
            {
                brack[i] = input[i - 1];
            }

            for (int i = 1; i <= n; i++)
            {
                f[i, i] = 0;
            }

            for (int i = 1; i <= n - 1; i++)
            {
                if (brack[i] == '(' || brack[i] == '?')
                {
                    if (brack[i + 1] == '?' || brack[i + 1] == ')')
                    {
                        f[i, i + 1] = 1;
                    }
                    else
                    {
                        f[i, i + 1] = 0;
                    }
                }
                else
                {
                    f[i, i + 1] = 0;
                }
            }

            long k = 0;
            for (int i = 2; i <= n - 1; i++)
            {
                for (int j = 1; j <= n - i; j++)
                {
                    k = 0;
                    if (i % 2 == 0 || brack[j] == ')' || brack[j + i] == '(')
                    {
                        f[j, j + i] = 0;
                    }
                    else
                    {
                        for (int r = j + 1; r <= j + i; r++)
                        {
                            if (brack[r] == ')' || brack[r] == '?')
                            {
                                if (r != j + 1)
                                {
                                    num1 = f[j + 1, r - 1];
                                }
                                else
                                {
                                    num1 = 1;
                                }

                                if (r != j + i)
                                {
                                    num2 = f[r + 1, j + i];
                                }
                                else
                                {
                                    num2 = 1;
                                }

                                k = k + (num1 * num2);
                            }
                        }

                        f[j, j + i] = k;
                    }
                }
            }

            Console.WriteLine(f[1, n]);
        }
    }
}
