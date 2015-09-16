namespace FlyweightFiguresDemo
{
    using System;

    public class Client
    {
        private static readonly string[] Keys = { "circle", "triangle", "rectangle" };        

        public static void Main()
        {
            Random random = new Random();
            var factory = new FlyweightShapeFactory();            

            for (int i = 0; i < 10; i++)
            {
                var shape = factory.GetShape(Keys[random.Next(0, Keys.Length)]);
                shape.Print();
            }

            Console.WriteLine("After 10 request there are {0} objects in the Flyweight Shape Factory", factory.NumberOfObjects);            
        }
    }
}
