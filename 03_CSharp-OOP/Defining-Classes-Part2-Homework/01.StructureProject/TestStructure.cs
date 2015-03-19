namespace _01.StructureProject
{
    using System;
    class TestStructure
    {
        static void Main()
        {
            // Creating an array of points
            Point3D[] arrayPoints3D = new[] 
            {
                new Point3D(10, 20, 30),
                new Point3D(15, 25, 35),
                new Point3D(25, 30, 50),
                new Point3D(35, 50, 60),
            };

            // testing ToString() functionality
            Console.WriteLine(arrayPoints3D[2]);

            // testing the distance between two points from the array
            Console.WriteLine("The distance between the two points is {0:F2}\n"
                , DistanceIn3DWorld.DistanceIn3DSpace(arrayPoints3D[0], arrayPoints3D[1]));

            // Creating a Path with arrayPoints3D
            Path path = new Path(arrayPoints3D);

            // testing the Counter
            Console.WriteLine("Path has {0} elements\n", path.Count);

            path.AddPoint(new Point3D(40, 60, 65));

            Console.WriteLine("After adding one more elements Path count is {0}\n", path.Count);

            // testing the option to write Path to an external file
            PathStorage.SavePath(path);
            Console.WriteLine("The final result can be found at 01.StructureProject main directory as pointsPath.txt\n");

            // Reading from the same external file from PathStorage.SavePath(path)
            Path readTextFile = PathStorage.ReadPath();

            // displaying the information
            foreach (var point in readTextFile)
            {
                Console.WriteLine(point);
            }
            Console.WriteLine();
        }
    }
}
