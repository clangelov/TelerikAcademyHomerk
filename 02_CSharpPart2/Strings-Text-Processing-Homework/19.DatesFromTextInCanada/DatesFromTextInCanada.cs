/*
 * Problem 19. Dates from text in Canada
 * Write a program that extracts from a given text all dates that match the format DD.MM.YYYY.
 * Display them in the standard date format for Canada.
*/
using System;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
class DatesFromTextInCanada
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");;

        Console.WriteLine("Enter some text with dates in the format DD.MM.YYYY:");
        string inputText = Console.ReadLine();
        /*
         * I was born at 14.06.1980. My sister was born at 3.7.1984. In 5/1999 I graduated my high school. The law says (see section 7.3.12) that we are allowed to do this (section 7.4.2.9).
        */

        List<string> dates = new List<string>();
        
        string regexCondition = @"[0-9]+\.[0-9]+\.[0-9]{4}";

        Regex myRegex = new Regex(regexCondition, RegexOptions.None);

        foreach (Match myMatch in myRegex.Matches(inputText))
        {
            if (myMatch.Success)
            {
                dates.Add(myMatch.ToString());
            }
        }

        Console.WriteLine("Dates with Canadian regional settings:");
        
        for (int i = 0; i < dates.Count; i++)
        {
            int[] dateArr = dates[i]
            .Split(new char[]{'.', ' ', ':'}, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .ToArray();

            DateTime canadaDate = new DateTime(dateArr[2], dateArr[1], dateArr[0]);

            Console.WriteLine("{0:d}", canadaDate);
        }
    }
}

