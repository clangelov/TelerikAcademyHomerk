namespace Task04._5.ExamBitsToBits
{
    using System;
    
    // 80 Pts At Exam
    public class BitsToBits
    {
        private const char ZeroAsciiSymbol = '0';
        private const char OneAsciiSymbol = '1';

        public static void Main()
        {            
            int inputLength = int.Parse(Console.ReadLine());

            string result = string.Empty;

            result = TransformInputToString(inputLength);

            FindLongestsequences(result);           
        }

        private static void FindLongestsequences(string result)
        {
            int currentCountOfZero = 1;
            int zeroMaxCount = 1;
            int currentCountOfOnes = 1;
            int onesMaxCount = 1;

            for (int i = 0; i < result.Length - 1; i++)
            {
                if (result[i] == OneAsciiSymbol && result[i + 1] == OneAsciiSymbol)
                {
                    currentCountOfOnes++;
                    if (onesMaxCount < currentCountOfOnes)
                    {
                        onesMaxCount = currentCountOfOnes;
                    }
                }
                else
                {
                    currentCountOfOnes = 1;
                }

                if (result[i] == ZeroAsciiSymbol && result[i + 1] == ZeroAsciiSymbol)
                {
                    currentCountOfZero++;
                    if (zeroMaxCount < currentCountOfZero)
                    {
                        zeroMaxCount = currentCountOfZero;
                    }
                }
                else
                {
                    currentCountOfZero = 1;
                }
            }

            Console.WriteLine(zeroMaxCount);
            Console.WriteLine(onesMaxCount);
        }

        private static string TransformInputToString(int inputLength)
        {
            string result = string.Empty;

            for (int i = 0; i < inputLength; i++)
            {
                long number = long.Parse(Console.ReadLine());
                string numberAsBinaryString = Convert.ToString(number, 2).PadLeft(30, '0');
                result += numberAsBinaryString;
            }

            return result;
        }
    }
}
