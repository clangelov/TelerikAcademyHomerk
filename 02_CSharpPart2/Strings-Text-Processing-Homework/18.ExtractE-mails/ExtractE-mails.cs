/*
 * Problem 18. Extract e-mails
 * Write a program for extracting all email addresses from given text.
 * All sub-strings that match the format <identifier>@<host>…<domain> should be recognized as emails.
*/
using System;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter some text:");
        /*
         * Please contact us by phone (+359 222 222 222) or by email at example@abv.bg or at baj.ivan@yahoo.co.uk. This is not email: test@test. This also: @telerik.com. Neither this: a@a.b.
         *        
        */
        string inputText = Console.ReadLine();

        // creating a pattern how e-mails look like
        string regexCondition = @"[A-Za-z0-9_\-\+]+@[A-Za-z0-9\-]+\.([A-Za-z]{2,3})(?:\.[a-z]{2})?";
                
        Regex myRegex = new Regex(regexCondition, RegexOptions.None);

        Console.WriteLine("The text contained the following e-mails:");
        
        // Match represents the result from Regex.Matches 
        foreach (Match myMatch in myRegex.Matches(inputText))
        {            
            if (myMatch.Success)
            {
                Console.WriteLine(myMatch);
            }
        }        
    }
}

