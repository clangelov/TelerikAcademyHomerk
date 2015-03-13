/*
 * Problem 15. Replace tags
 * Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL].
 * Example:
 * input	
 * 
 * <p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>
 * 
 * output
 * 
 * <p>Please visit [URL=http://academy.telerik.com]our site[/URL] to choose a training course. Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>
*/
using System;
using System.Text.RegularExpressions;
class ReplaceTags
{
    static void Main()
    {
        Console.WriteLine("Enter a HTML document as text: ");
        string inputText = Console.ReadLine();

        string openReplace = "[URL=";
        string endReplace = "[/URL]";

        // maybe it can be done on one single line ?!
        inputText = Regex.Replace(inputText, "a href=", openReplace);
        inputText = Regex.Replace(inputText, "</a>", endReplace);

        Console.WriteLine("Replaced text:");
        Console.WriteLine(inputText);
    }
}

