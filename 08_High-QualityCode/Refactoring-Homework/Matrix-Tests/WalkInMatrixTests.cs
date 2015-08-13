namespace Matrix_Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WalkInMatrixTests
    {
        [TestMethod]
        public void TestWalkInMatrixWithSizeThree()
        {
            int matrixSize = 3;
            var matrix = Matrix.WalkInMatrix.FillMatrix(matrixSize);
            var expected = new int[,] 
            { 
                { 1, 7, 8 },
                { 6, 2, 9 },
                { 5, 4, 3 }
            };

            Assert.IsTrue(this.CompareTwoMatrixByValue(expected, matrix));
        }

        [TestMethod]
        public void TestWalkInMatrixWithSizeSix()
        {
            int matrixSize = 6;
            var matrix = Matrix.WalkInMatrix.FillMatrix(matrixSize);
            var expected = new int[,] 
            { 
                { 1, 16, 17, 18, 19, 20 },
                { 15, 2, 27, 28, 29, 21 },
                { 14, 31, 3, 26, 30, 22 },
                { 13, 36, 32, 4, 25, 23 },
                { 12, 35, 34, 33, 5, 24 },
                { 11, 10, 9, 8, 7, 6 }
            };

            Assert.IsTrue(this.CompareTwoMatrixByValue(expected, matrix));
        }

        private bool CompareTwoMatrixByValue(int[,] expected, int[,] actual)
        {
            if (expected.GetLength(0) != actual.GetLength(0) || expected.GetLength(1) != actual.GetLength(1))
            {
                return false;
            }

            for (int row = 0; row < expected.GetLength(0); row++)
            {
                for (int col = 0; col < expected.GetLength(1); col++)
                {
                    if (expected[row, col] != actual[row, col])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
