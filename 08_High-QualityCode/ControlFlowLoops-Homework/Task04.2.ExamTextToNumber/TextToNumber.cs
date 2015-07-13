namespace Task04._2.ExamTextToNumber
{
    using System;

    public class TextToNumber
    {
        private const char EndOperationsSymbol = '@';

        public static void Main()
        {
            int moduleNumber = int.Parse(Console.ReadLine());

            string inputText = Console.ReadLine();

            ulong result = TransformTextToNumber(inputText, moduleNumber);

            Console.WriteLine(result);
        }

        private static ulong TransformTextToNumber(string input, int moduleNumber)
        {
            string inputText = input.ToUpper();

            ulong result = 0;

            for (int i = 0; i < inputText.Length; i++)
            {
                if (inputText[i] == EndOperationsSymbol)
                {
                    break;
                }
                else if (char.IsDigit(inputText[i]))
                {
                    // Transofrms the ASCII Code of the symbol to the actual number
                    result *= (ulong)(inputText[i] - '0');
                }
                else if (char.IsLetter(inputText[i]))
                {
                    // Transofrms the ASCII Code of the symbol to the actual postion in the Alphabet
                    result += (ulong)(inputText[i] - 'A');
                }
                else
                {
                    result %= (ulong)moduleNumber;
                }
            }

            return result;
        }
    }
}
