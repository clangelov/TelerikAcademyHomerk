namespace Task04._4.ExamCube
{
    using System;
    using System.Text;

    public class Cube
    {
        private const char LetterX = 'X';
        private const char Space = ' ';
        private const char Dash = '-';
        private const char Colon = ':';
        private const char Slash = '/';

        public static void Main()
        {
            int sizeOfCube = int.Parse(Console.ReadLine());

            string cubeAsString = string.Empty;

            cubeAsString += CubeFirstRow(sizeOfCube);

            cubeAsString += CubeUppertPart(sizeOfCube);

            cubeAsString += CubeMiddleRow(sizeOfCube);

            cubeAsString += CubeLowerPart(sizeOfCube);

            cubeAsString += CubeLastRow(sizeOfCube);

            Console.Write(cubeAsString);
        }

        // A lot of Magic numbers
        private static string CubeFirstRow(int sizeOfCube)
        {
            var firstRow = new StringBuilder();
            firstRow.Append(new string(Space, sizeOfCube - 1));
            firstRow.Append(new string(Colon, sizeOfCube));
            firstRow.AppendLine();
            return firstRow.ToString();
        }

        private static string CubeUppertPart(int sizeOfCube)
        {
            var upperPart = new StringBuilder();
            for (int i = 0; i < sizeOfCube - 2; i++)
            {
                upperPart.Append(new string(Space, (sizeOfCube - 2) - i));
                upperPart.Append(Colon);
                upperPart.Append(new string(Slash, sizeOfCube - 2));
                upperPart.Append(Colon);
                upperPart.Append(new string(LetterX, i));
                upperPart.Append(Colon);
                upperPart.AppendLine();
            }

            return upperPart.ToString();
        }

        private static string CubeMiddleRow(int sizeOfCube)
        {
            var middleRow = new StringBuilder();
            middleRow.Append(new string(Colon, sizeOfCube));
            middleRow.Append(new string(LetterX, sizeOfCube - 2));
            middleRow.Append(Colon);
            middleRow.AppendLine();
            return middleRow.ToString();
        }

        private static string CubeLowerPart(int sizeOfCube)
        {
            var lowerPart = new StringBuilder();
            for (int i = 0; i < sizeOfCube - 2; i++)
            {
                lowerPart.Append(Colon);
                lowerPart.Append(new string(Space, sizeOfCube - 2));
                lowerPart.Append(Colon);
                lowerPart.Append(new string(LetterX, sizeOfCube - 3 - i));
                lowerPart.Append(Colon);
                lowerPart.Append(new string(Space, i + 1));
                lowerPart.AppendLine();
            }

            return lowerPart.ToString();
        }

        private static string CubeLastRow(int sizeOfCube)
        {
            var lastRow = new StringBuilder();
            lastRow.Append(new string(Colon, sizeOfCube));
            lastRow.Append(new string(Space, sizeOfCube - 1));
            lastRow.AppendLine();
            return lastRow.ToString();
        }
    }
}
