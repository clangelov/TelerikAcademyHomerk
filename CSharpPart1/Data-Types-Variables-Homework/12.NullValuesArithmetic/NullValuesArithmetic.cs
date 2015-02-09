using System;
class NullValuesArithmetic
{
    /* Problem 12. Null Values Arithmetic
     * Create a program that assigns null values to an integer and to a double variable.
     * Try to print these variables at the console.
     * Try to add some number or the null literal to these variables and print the result.
    */
    static void Main()
    {
        int? firstNumber = null;
        double? secondNumber = null;

        Console.WriteLine("Int = {0}", firstNumber);
        Console.WriteLine("Double = {0}", secondNumber);

        firstNumber = 255000;
        secondNumber = 3.14;

        Console.WriteLine("Int = {0}", firstNumber);
        Console.WriteLine("Double = {0}", secondNumber);
    }
}

