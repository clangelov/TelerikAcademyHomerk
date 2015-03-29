namespace _01.Shapes
{
    // Define class Square and suitable constructor so that at initialization height must be kept equal to width and implement the CalculateSurface() method.
    class Square : Shape
    {
        public Square(double hight)
            : base(hight, hight)
        {
        }
        public override double CalculateSurface()
        {
            return this.Height * this.Height;
        }
    }
}
