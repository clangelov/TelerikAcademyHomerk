using System;
class ThirdDigit7
{
    /* Problem 5. Third Digit is 7?
     * Write an expression that checks for given integer if its third digit from right-to-left is 7.
    */
    static void Main()
    {
        int a, b, c;
        Console.Write("Please enter a number: ");
        a = int.Parse(Console.ReadLine());
        b = a / 100;
        c = b % 10;
        bool seven = (c == 7);
        Console.WriteLine("The 3rd digit is 7: {0}!", seven);
    }
}

