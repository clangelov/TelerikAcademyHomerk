// Problem 1. StringBuilder.Substring
namespace _01.StringBuilderSubstring
{
    using System;
    using System.Text;
    class TestStringBuilder
    {
        static void Main()
        {
            StringBuilder testStrBuilder = new StringBuilder("hello I are baboon");

            var testOne = testStrBuilder.Substring(0, 5);
            Console.WriteLine("Taking the first five symbols: {0}", testOne.ToString());

            testOne = testStrBuilder.Substring(6);
            Console.WriteLine("Taking all symbols after the 6th: {0}", testOne);
        }       
    }
}
