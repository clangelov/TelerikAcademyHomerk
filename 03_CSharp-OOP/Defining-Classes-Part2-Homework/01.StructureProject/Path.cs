/*
 * Problem 4. Path
 * Create a class Path to hold a sequence of points in the 3D space.
*/
namespace _01.StructureProject
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    // inheriting :IEnumerable interface in order to be able to use foreach with Path
    class Path : IEnumerable
    {
        private List<Point3D> pointsPath;

        // default empty constructur
        public Path()
        {
            this.pointsPath = new List<Point3D>();
        }

        // constructur with the option to add an array of Point3D
        public Path(params Point3D[] input)
        {
            this.pointsPath = new List<Point3D>(input);
        }

        // method for adding points
        public void AddPoint(Point3D input)
        {
            this.pointsPath.Add(input);
        }

        // metohd for counting the number of elements in the Path
        public int Count
        {
            get { return this.pointsPath.Count; }
        }

        public IEnumerator GetEnumerator()
        {
            return this.pointsPath.GetEnumerator();
        }

    }
}
