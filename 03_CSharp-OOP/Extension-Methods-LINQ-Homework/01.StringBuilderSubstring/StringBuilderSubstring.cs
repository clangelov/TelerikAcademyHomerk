/*
 * Problem 1. StringBuilder.Substring
 * Implement an extension method Substring(int index, int length) for the class StringBuilder that returns new StringBuilder and has the same functionality as Substring in the class String.
*/
namespace _01.StringBuilderSubstring
{
    using System;
    using System.Text;
    public static class StringBuilderSubstring
    {
        // option one with a start index and lenght of the symbols
        public static StringBuilder Substring(this StringBuilder strBuilder, int startIndex, int lenght)
        {
            if (strBuilder.Capacity == 0)
            {
                throw new ArgumentException("Can not proceed with an empty String Builder");
            }

            string input = strBuilder.ToString();

            if (startIndex < 0 || (lenght + startIndex) > input.Length)
            {
                throw new ArgumentOutOfRangeException("Can not operate outside the boundaries of the String Builder");
            }

            var result = new StringBuilder();

            for (int i = startIndex; i < (lenght + startIndex); i++)
            {
                result.Append(input[i]);
            }

            return result;
        }

        // option two giving only the start index
        public static StringBuilder Substring(this StringBuilder strBuilder, int startIndex)
        {
            if (strBuilder.Capacity == 0)
            {
                throw new ArgumentException("Can not proceed with an empty String Builder");
            }

            string input = strBuilder.ToString();

            if (startIndex < 0 || startIndex > input.Length)
            {
                throw new ArgumentOutOfRangeException("Can not operate outside the boundaries of the String Builder");
            }

            var result = new StringBuilder();

            for (int i = startIndex; i < input.Length; i++)
            {
                result.Append(input[i]);
            }

            return result;
        }
    }
}
