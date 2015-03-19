namespace _03.MatrixProject
{
    using System;
    class TestMatrix
    {
        static Random rndGenerator = new Random();
        static void Main()
        {
            // Creating two matrices to be tested
            Matrix<int> firstMatrix = new Matrix<int>(3, 4);
            Console.WriteLine("First Matrix Capacity is {0}\n", firstMatrix.Capacity);

            Matrix<int> secondMatrix = new Matrix<int>(3, 4);

            FillMatrixWithInt(firstMatrix);
            Console.WriteLine("First Matrix:");
            Console.WriteLine(firstMatrix.ToString());

            FillMatrixWithInt(secondMatrix);
            Console.WriteLine("Second Matrix:");
            Console.WriteLine(secondMatrix.ToString());

            // test operator +
            firstMatrix += secondMatrix;
            Console.WriteLine("Applying the operator +");
            Console.WriteLine(firstMatrix.ToString());

            // test operator -
            firstMatrix -= secondMatrix;
            Console.WriteLine("Applying the operator -");
            Console.WriteLine(firstMatrix.ToString());

            // test operator *
            firstMatrix *= secondMatrix;
            Console.WriteLine("Applying the operator *");
            Console.WriteLine(firstMatrix.ToString());

            // test method bool
            Matrix<double> testBool = new Matrix<double>(1, 1);
            testBool[0, 0] = 0.0;
            if (testBool)
            {
                Console.WriteLine("testBool does not contain Zero");
            }
            else
            {
                Console.WriteLine("testBool contains Zero");
            }
            Console.WriteLine();
        }

        static void FillMatrixWithInt(Matrix<int> input)
        {
            for (int row = 0; row < input.Rows; row++)
            {
                for (int col = 0; col < input.Cols; col++)
                {
                    input[row, col] = rndGenerator.Next(0, 10);
                }
            }
        }        
    }
}
