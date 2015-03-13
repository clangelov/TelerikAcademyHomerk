using System;
class FormattingNumbers
{
    /* Problem 5. Formatting Numbers
     * Write a program that reads 3 numbers:
     * integer a (0 <= a <= 500)
     * floating-point b
     * floating-point c
     * The program then prints them in 4 virtual columns on the console. Each column should have a width of 10 characters.
     * The number a should be printed in hexadecimal, left aligned
     * Then the number a should be printed in binary form, padded with zeroes
     * The number b should be printed with 2 digits after the decimal point, right aligned
     * The number c should be printed with 3 digits after the decimal point, left aligned.
    */
    static void Main()
    {
        Console.Write("a = ");
        int a = int.Parse(Console.ReadLine());
        
        while ((a < 0) || (a > 500))
        {
            Console.WriteLine("a need to be in range 0 <= a <= 500");
            Console.Write("a =  ");
            a = int.Parse(Console.ReadLine());
        }
        
        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine()); 
        Console.Write("c = ");
        double c = double.Parse(Console.ReadLine());

        Console.Write("{0,-10:X}", a);
        string binary = Convert.ToString(a, 2).PadLeft(10, '0');
        Console.Write("|{0,-10}|", binary);
        Console.Write(b % 1 == 0 ? "{0,10}|" : "{0,10:F2}|", b);
        Console.Write(c % 1 == 0 ? "{0,-10}|" : "{0,-10:F3}|\n", c);
               
    }
}

