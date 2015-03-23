/*
 * Problem 17. Longest string
 * Write a program to return the string with maximum length from an array of strings.
 * Use LINQ.
*/
namespace _17.LongestString
{
    using System;
    using System.Linq;
    class LongestString
    {
        static void Main()
        {
            string[] someLyrics = new[] {
            "Cheers to the freakin' weekend",
            "I drink to that, yeah yeah",
            "Oh let the Jameson sink in",
            "I drink to that, yeah yeah",
            "Don't let the bastards get ya down",
            "Turn it around with another round",
            "There's a party at the bar",
            "Everybody putcha glasses up and I drink to that (yeah yeah yeah)"};

            var longestString = from longStr in someLyrics
                                orderby longStr.Length descending // the longest string will be at first position
                                select longStr;

            Console.WriteLine(longestString.First()); // the console will write only the first string
        }
    }
}
