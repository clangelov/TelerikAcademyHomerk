namespace Task01.BinaryPasswords
{
    using System;
    using System.Linq;

    public class Stratup
    {
        public static void Main()
        {
            char[] input = Console.ReadLine().Where(x => x == '*').ToArray();

            if (input.Length == 0)
            {
                Console.WriteLine(1);
                return;
            }

            ulong result = 2;

            for (int i = 0; i < input.Length - 1; i++)
            {
                result *= 2;
            }

            Console.WriteLine(result);
        }
    }
}
