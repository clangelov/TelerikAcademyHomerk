## Data Structures, Algorithms and Complexity
### _Homework_

#### Info note for this homework:
Big O gives the upperbound - the worst possible execution time of an algorithm. And Ω is the converse of O, ie, the lowest estimate. Θ is somewhere inbetween. 
More info: [Link to an article](https://www.quora.com/What-are-some-easy-ways-to-understand-and-calculate-the-time-complexity-of-algorithms)

__Task 1.__ What is the expected running time of the following C# code? Explain why.
  - Assume the array's size is `n`.

~~~c#
long Compute(int[] arr)
{
    long count = 0;
    for (int i=0; i<arr.Length; i++)	// This would take n operation before finish
    {									// From zero to n
        int start = 0, end = arr.Length-1;
        while (start < end)				// This will perform n-1 operations
            if (arr[start] < arr[end])	
                { start++; count++; }
            else 
                end--;
    }
    return count;
}
~~~

#### Answer to task 1
The complexity of the code would be 0(n^2) (quadratic time).

- - - -

__Task 2.__ What is the expected running time of the following C# code?
  - Explain why.
  - Assume the input matrix has size of n * m.

~~~c#
long CalcCount(int[,] matrix)
{
    long count = 0;
    for (int row=0; row<matrix.GetLength(0); row++) // The operation will perform n times
        if (matrix[row, 0] % 2 == 0)
            for (int col=0; col<matrix.GetLength(1); col++) // The operation will perform m times
                if (matrix[row,col] > 0)					// In worst case scenario
                    count++;
    return count;
}
~~~

#### Answer to task 2
The complexity of the code would be O(n*m) (quadratic time).

- - - -

__Task 3.*__ What is the expected running time of the following C# code?
  - Explain why.
  - Assume the input matrix has size of n * m.

~~~c#
long CalcSum(int[,] matrix, int row)
{
    long sum = 0;
    for (int col = 0; col < matrix.GetLength(0); col++) // The operation will perform m times
        sum += matrix[row, col];
    if (row + 1 < matrix.GetLength(1)) 
        sum += CalcSum(matrix, row + 1);  // The operation will perform n times
    return sum;
}

Console.WriteLine(CalcSum(matrix, 0));
~~~

#### Answer to task 3
The complexity of the code would be O(n*m) (quadratic time).