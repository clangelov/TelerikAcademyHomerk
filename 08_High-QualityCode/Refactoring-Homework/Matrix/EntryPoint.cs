namespace Matrix
{
    using System;

    public static class EntryPoint
    {
        private const int MinMatrixSize = 0;
        private const int MaxMatrixSize = 100;
        
        public static void Main()
        {
            int matrixSize = ReadInputFromConsole();
            int[,] matrix = WalkInMatrix.FillMatrix(matrixSize);
            var loger = new Logger();
            loger.PrintMatrixToConsole(matrix);            
        }

        private static int ReadInputFromConsole()
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            int matrixSize = 0;
            while (!int.TryParse(input, out matrixSize) || matrixSize < MinMatrixSize || matrixSize > MaxMatrixSize)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            return matrixSize;
        }
    }
}
