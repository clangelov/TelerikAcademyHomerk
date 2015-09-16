namespace FlyweightFiguresDemo
{
    using System;

    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    public class Circle : IShape
    {
        public void Print()
        {
            Console.WriteLine("Drawing a {0} to the console", this.GetType().Name);
        }
    }
}
