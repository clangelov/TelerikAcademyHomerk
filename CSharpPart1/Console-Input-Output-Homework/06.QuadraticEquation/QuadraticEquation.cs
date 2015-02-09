using System;
class QuadraticEquation
{
    /* Problem 6. Quadratic Equation
     * Write a program that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0 and solves it (prints its real roots).
    */
    static void Main()
    {
        double a, b, c, discriminant, root1, root2;
        
        Console.Write("a = ");
        a = double.Parse(Console.ReadLine());
        Console.Write("b = ");
        b = double.Parse(Console.ReadLine());
        Console.Write("c = ");
        c = double.Parse(Console.ReadLine());
        
        discriminant = (b * b) - (4 * a * c);
        
        if (discriminant > 0)
        {
            root1 = (-b - Math.Sqrt(discriminant)) / (2 * a); 
            root2 = (-b + Math.Sqrt(discriminant)) / (2 * a);                    
            Console.WriteLine("x1 = {0}", root1);
            Console.WriteLine("x2 = {0}", root2);
        }
        else if (discriminant == 0)
        {
            root1 = root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);            
            Console.WriteLine("x = {0}", root1);
        }
        else
        {
            Console.WriteLine("No real roots.");
        }
    }
}

