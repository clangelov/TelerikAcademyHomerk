using System;
class Play
{
    /* Problem 9. Play with Int, Double and String
     * Write a program that, depending on the user’s choice, inputs an int, double or string variable.
     * If the variable is int or double, the program increases it by one.
     * If the variable is a string, the program appends * at the end.
     * Print the result at the console. Use switch statement
    */
    static void Main()
    {
        Console.WriteLine("Please choose a type:");
        Console.WriteLine("1 --> int");
        Console.WriteLine("2 --> double");
        Console.WriteLine("3 --> string");

        Console.Write("User: ");
        int number = int.Parse(Console.ReadLine());

        switch (number)
        {
            case 1:
                Console.Write("Please enter an int: ");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine("{0}", a + 1);
                break;
            case 2:
                Console.Write("Please enter a double: ");
                double b = double.Parse(Console.ReadLine());
                Console.WriteLine("{0}", b + 1); 
                break;
            case 3:
                Console.Write("Please enter a string: ");
                string text = Console.ReadLine();
                Console.WriteLine("{0}*", text); 
                break;
            default:
                Console.WriteLine("Invalid input"); 
                break;
        }
    }
}

