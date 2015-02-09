using System;
class NumberComparer
{
    /* Problem 4. Number Comparer
     * Write a program that gets two numbers from the console and prints the greater of them.
     * Try to implement this without if statements.
    */
    static void Main()
    {
        decimal a, b;

        Console.Write("a = ");
        a = decimal.Parse(Console.ReadLine());
        Console.Write("b = ");
        b = decimal.Parse(Console.ReadLine());

        Console.WriteLine("The greater number is {0}", Math.Max(a, b));
    }
}

