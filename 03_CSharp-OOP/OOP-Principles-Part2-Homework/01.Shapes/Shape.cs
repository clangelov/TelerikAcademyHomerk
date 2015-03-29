namespace _01.Shapes
{
    using System;

    // Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height.
    abstract class Shape
    {
        private double width;
        private double height;

        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (CheckValue(value))
                {
                    this.width = value;
                }
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (CheckValue(value))
                {
                    this.height = value;
                }
            }
        }

        private bool CheckValue(double value)
        {
            if (value < 1)
            {
                throw new ArgumentOutOfRangeException("Width and Hight can not be less than 1");
            }

            return true;
        }

        // the method has empty body, it will be mandatory implemented by the "kids" of shape
        public abstract double CalculateSurface(); 
    }
}
