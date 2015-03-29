/*
 * Problem 1. Shapes
 * Write a program that tests the behaviour of the CalculateSurface() method for different shapes (Square, Rectangle, Triangle) stored in an array.
*/
namespace _01.Shapes
{
    using System;
    class TestShapes
    {
        static void Main()
        {
            var testShapes = new Shape[]
            {
                new Triangle(7.5 , 12),
                new Triangle(5 , 7.5),

                new Square(5),
                new Square(3.75),

                new Rectangle(1.5, 10),
                new Rectangle(3, 6.45),
            };

            foreach (var shapes in testShapes)
            {
                Console.WriteLine(string.Format("{0} has a surface of {1}"
                    , shapes.GetType().Name, shapes.CalculateSurface()));
            }

            Console.WriteLine();
        }
    }
}
