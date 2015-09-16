namespace FlyweightFiguresDemo
{
    using System;

    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    public class Traingle : IShape
    {
        public void Print()
        {
            Console.WriteLine("Drawing a {0} to the console", this.GetType().Name);
        }
    }
}
