/*
 * Problem 4. Path
 * Create a static class PathStorage with static methods to save and load paths from a text file.
 * Use a file format of your choice.
*/
namespace _01.StructureProject
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    static class PathStorage
    {
        // setting the adress of the file
        private static string fileName = @"..\..\pointsPath.txt";

        public static void SavePath(Path input)
        {
            StreamWriter savePath = new StreamWriter(fileName);
            using (savePath)
            {
                // writting a line for each element in the Path
                foreach (var Point3D in input)
                {
                    savePath.WriteLine(Point3D);
                }
            }
        }

        public static Path ReadPath()
        {
            Path result = new Path();

            StreamReader readPoints = new StreamReader(fileName);

            using (readPoints)
            {
                while (!readPoints.EndOfStream) // As longs as there are lines in the pointsPath.txt this will execute
                {
                    string[] coordinates = readPoints.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Where(x => x.Contains('=')) // extracting only the words e.g. x=15, y=20, z=25
                        .ToArray();

                    // using a Method to create a Point3D
                    result.AddPoint(ParsePoint(coordinates));
                }
            }

            return result;
        }

        private static Point3D ParsePoint(string[] coordinates)
        {
            string result = string.Empty;
            // here I will hold the coordinates of the Point3D
            int[] points = new int[3];

            for (int i = 0; i < coordinates.Length; i++)
            {
                // replacing all words with Regex condition @"[^\d]" with ""
                result = Regex.Replace(coordinates[i], @"[^\d]", "");
                points[i] = int.Parse(result);
                result = string.Empty;
            }

            Point3D addToPath = new Point3D(points[0], points[1], points[2]);

            return addToPath;
        }
    }
}
