/*
 * Problem 1. Structure
 * Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space.
*/
namespace _01.StructureProject
{
    using System;
    using System.Text;
    public struct Point3D
    {
        public int pointX { get; set; }
        public int pointY { get; set; }
        public int pointZ { get; set; }

        // Problem 2. Static read-only field
        // Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}.
        private static readonly Point3D pointO = new Point3D(0, 0, 0);

        // whitout the empty constructor  : this()  it won't work. For structures is mandatory to have an empty constructor
        public Point3D(int pointX, int pointY, int pointZ)
            : this()
        {
            this.pointX = pointX;
            this.pointY = pointY;
            this.pointZ = pointZ;
        }

        // Problem 2. Add a static property to return the pointO.
        public static Point3D PointO
        {
            get { return Point3D.pointO; }
        }

        // Implement the ToString() to enable printing a 3D point.
        public override string ToString()
        {
            return string.Format("The point has the following coordinates: x={0}, y={1}, z={2}",
                this.pointX, this.pointY, this.pointZ);
        }
    }
}
