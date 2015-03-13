using System;
class ExchangeVariableValues
{
    /* Problem 9. Exchange Variable Values
     * Declare two integer variables a and b and assign them with 5 and 10 and after that exchange their values by using some programming logic.
     * Print the variable values before and after the exchange.
    */
    static void Main()
    {
        
        int a = 5;
        Console.WriteLine("a = {0}", a);
        int b = 10;
        Console.WriteLine("b = {0}", b);
        a = a ^ b;
        b = a ^ b;
        a = a ^ b;
        Console.WriteLine("a = {0}", a);
        Console.WriteLine("b = {0}", b);
    }
}

