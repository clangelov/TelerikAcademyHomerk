namespace FlyweightFiguresDemo
{
    using System;
    using System.Collections.Generic;

    public class FlyweightShapeFactory
    {
        private readonly Dictionary<string, IShape> shapes = new Dictionary<string, IShape>();

        public int NumberOfObjects
        {
            get
            {
                return this.shapes.Count;
            }
        }

        public IShape GetShape(string key)
        {
            // Uses "lazy initialization"
            IShape shape = null;
            if (this.shapes.ContainsKey(key))
            {
                shape = this.shapes[key];
            }
            else
            {
                switch (key)
                {
                    case "circle":
                        shape = new Circle();
                        break;
                    case "triangle":
                        shape = new Traingle();
                        break;
                    case "rectangle":
                        shape = new Rectangle();
                        break;
                    default:
                        throw new InvalidOperationException("This is an invalid command");
                }

                this.shapes.Add(key, shape);
            }

            return shape;
        }
    }
}
