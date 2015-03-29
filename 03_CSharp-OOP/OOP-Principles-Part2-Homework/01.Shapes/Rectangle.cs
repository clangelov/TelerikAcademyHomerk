namespace _01.Shapes
{
    // Define Rectangle class that implement the virtual method and return the surface of the figure
    class Rectangle : Shape
    {
        public Rectangle(double width, double height)
            : base(width, height)
        {
        }
        public override double CalculateSurface()
        {
            return this.Width * this.Height;
        }
    }
}
