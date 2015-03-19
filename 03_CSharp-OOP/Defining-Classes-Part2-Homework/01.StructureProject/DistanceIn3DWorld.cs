/*
 * Problem 3. Static class
 * Write a static class with a static method to calculate the distance between two points in the 3D space.
*/
namespace _01.StructureProject
{
    using System;
    static class DistanceIn3DWorld
    {
        public static double DistanceIn3DSpace(Point3D firstPoint, Point3D secondPoint)
        {
            double distance = 0;

            // the formula is from http://en.wikipedia.org/wiki/Euclidean_distance
            distance = Math.Sqrt((Math.Pow((firstPoint.pointX - secondPoint.pointX), 2) +
                        Math.Pow((firstPoint.pointY - secondPoint.pointY), 2) +
                        Math.Pow((firstPoint.pointZ - secondPoint.pointZ), 2)));

            return distance;
        }
    }
}
