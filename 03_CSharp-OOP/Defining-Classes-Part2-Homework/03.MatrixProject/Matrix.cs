/*
 * Problem 8. Matrix
 * Define a class Matrix<T> to hold a matrix of numbers
*/
namespace _03.MatrixProject
{
    using System;
    using System.Text;
    class Matrix<T>
    {
        // fields
        private T[,] matrix;
        private int rows;
        private int cols;

        // constructor
        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            matrix = new T[rows, cols];
        }

        // properties
        public int Rows
        {
            get
            {
                return this.matrix.GetLength(0);
            }
            private set
            {
                this.rows = CheckInputData(value);
            }
        }

        public int Cols
        {
            get
            {
                return this.matrix.GetLength(1);
            }
            private set
            {
                this.cols = CheckInputData(value);
            }
        }

        // creating a method to check if the input data for Rows and Cols is correct
        private int CheckInputData(int value)
        {
            if (value < 1 || value > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException("The matrix size should be be between 1 and int.MaxValue");
            }
            else
            {
                return value;
            }
        }
        public int Capacity
        {
            get
            {
                return this.rows * cols;
            }
        }

        // Problem 9. Matrix indexer
        // Implement an indexer this[row, col] to access the inner matrix cells.
        public T this[int row, int col]
        {
            get
            {
                if ((row > this.rows || row < 0) ||
                    (col > this.cols || col < 0))
                {
                    throw new ArgumentOutOfRangeException("You tried to access a field outside the Matrix");
                }
                T result = matrix[row, col];
                return result;
            }
            set // from here later I will be able to add some data to the matrix
            {
                if ((row > this.rows || row < 0) ||
                    (col > this.cols || col < 0))
                {
                    throw new ArgumentOutOfRangeException("You tried to access a field outside the Matrix");
                }
                this.matrix[row, col] = value;
            }
        }
        /*
         * Problem 10. Matrix operations
         * Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication.
         * Throw an exception when the operation cannot be performed.
        */

        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Cols != secondMatrix.Cols || firstMatrix.Rows != secondMatrix.Rows)
            {
                throw new InvalidOperationException("Can not add to two different matrices");
            }

            Matrix<T> result = new Matrix<T>(firstMatrix.Rows, firstMatrix.Cols);

            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Cols; col++)
                {
                    // dynamic helps me to perform the action without casting T to something else
                    result[row, col] = firstMatrix[row, col] + (dynamic)secondMatrix[row, col];
                }
            }
            return result;
        }

        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Cols != secondMatrix.Cols || firstMatrix.Rows != secondMatrix.Rows)
            {
                throw new InvalidOperationException("Can not substract two different matrices");
            }

            Matrix<T> result = new Matrix<T>(firstMatrix.Rows, firstMatrix.Cols);

            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Cols; col++)
                {
                    result[row, col] = firstMatrix[row, col] - (dynamic)secondMatrix[row, col];
                }
            }
            return result;
        }

        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Cols != secondMatrix.Cols || firstMatrix.Rows != secondMatrix.Rows)
            {
                throw new InvalidOperationException("Can not multiply two different matrices");
            }

            Matrix<T> result = new Matrix<T>(firstMatrix.Rows, firstMatrix.Cols);

            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Cols; col++)
                {
                    result[row, col] = firstMatrix[row, col] * (dynamic)secondMatrix[row, col]; ;
                }
            }

            return result;
        }
        // Problem 10. Matrix operations
        // Implement the true operator (check for non-zero elements).
        private static bool OverrideBool(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.rows; row++)
            {
                for (int col = 0; col < matrix.cols; col++)
                {
                    // if there is only 1 element == 0 I get false
                    if (matrix[row, col] == (dynamic)0)
                        return false;
                }
            }
            return true;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            return OverrideBool(matrix);
        }

        public static bool operator false(Matrix<T> matrix)
        {
            return OverrideBool(matrix);
        }

        // this will help me to print the matrix in the TestMatrix.cs
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < this.rows; row++)
            {
                for (int col = 0; col < this.cols; col++)
                {
                    result.AppendFormat("{0,3} ", this.matrix[row, col]);
                }
                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
