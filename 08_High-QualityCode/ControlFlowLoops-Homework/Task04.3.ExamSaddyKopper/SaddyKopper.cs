namespace Task04._3.ExamSaddyKopper
{
    using System;
    using System.Numerics;

    // 50 Pts In BGCoder at Exam
    public class SaddyKopper
    {
        private const int MaxNumberOfTransformation = 10;

        public static void Main()
        {
            ulong inputNumber = ulong.Parse(Console.ReadLine());

            PerformNumberTransformations(inputNumber);            
        }

        private static void PerformNumberTransformations(ulong inputNumber)
        {
            int transformationsCount = 0;
            ulong sumOfDigits = 0;            
            BigInteger resultOfOperations = 1;
            BigInteger numberToBeSummedUp = inputNumber / 10;
            bool areTransformationsFinished = false;

            while (transformationsCount < 11 && !areTransformationsFinished)
            {
                while (numberToBeSummedUp > 0)
                {
                    sumOfDigits = SumDigits(numberToBeSummedUp);
                    resultOfOperations *= sumOfDigits;
                    numberToBeSummedUp /= 10;
                }

                transformationsCount++;

                if (resultOfOperations < 10 && transformationsCount <= MaxNumberOfTransformation)
                {
                    Console.WriteLine(transformationsCount);
                    Console.WriteLine(resultOfOperations);
                    areTransformationsFinished = true;
                }
                else if (transformationsCount == 9)
                {
                    Console.WriteLine(resultOfOperations);
                    areTransformationsFinished = true;
                }
                else
                {
                    numberToBeSummedUp = resultOfOperations / 10;
                    resultOfOperations = 1;
                }
            } 
        }

        private static ulong SumDigits(BigInteger numberToBeSummedUp)
        {
            ulong sumOfDigits = 0;

            string operate = Convert.ToString(numberToBeSummedUp);

            for (int i = 0; i < operate.Length; i += 2)
            {
                if (char.IsDigit(operate[i]))
                {
                    // Transofrms the ASCII Code of the symbol to the actual number
                    sumOfDigits += (ulong)(operate[i] - '0');
                }
            }

            return sumOfDigits;
        }
    }
}
