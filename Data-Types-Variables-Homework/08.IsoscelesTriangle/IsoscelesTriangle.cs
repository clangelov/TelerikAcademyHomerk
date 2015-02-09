using System;
class IsoscelesTriangle
{
    /* Problem 8. Isosceles Triangle
     * Write a program that prints an isosceles triangle of 9 copyright symbols ©
     * Note: The © symbol may be displayed incorrectly at the console so you may need to change the console character encoding to UTF-8 and assign a Unicode-friendly font in the console.
    */
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        char copyrightSign = '\u00A9';

        Console.WriteLine("   {0}   ", copyrightSign);
        Console.WriteLine("  {0} {0}  ", copyrightSign);
        Console.WriteLine(" {0}   {0} ", copyrightSign);
        Console.WriteLine("{0} {0} {0} {0}", copyrightSign);
    }
}

