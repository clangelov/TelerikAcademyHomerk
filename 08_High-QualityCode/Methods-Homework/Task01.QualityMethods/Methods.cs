namespace Task01.QualityMethods
{
    using System;
    using System.Linq;
    using Enum;

    internal class Methods
    {
        internal static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(NumberToDigit(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintFormatedNumberToConsole(1.3, StringFormatOtions.TwoDigitsAfterDecimalPoint);
            PrintFormatedNumberToConsole(0.75, StringFormatOtions.Persent);
            PrintFormatedNumberToConsole(2.30, StringFormatOtions.ShiftRight);

            bool isHorizontal = IsLineHorizontal(3, -1);
            bool isVertical = IsLineVertical(3, 2.5);
            Console.WriteLine("Horizontal? " + isHorizontal);
            Console.WriteLine("Vertical? " + isVertical);

            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));

            Student peter = new Student("Peter", "Ivanov", "From Sofia, born at 17.03.1992");
            Student stella = new Student("Stella", "Markova", "From Vidin, gamer, high results, born at 03.11.1993");

            var isPeterOlder = peter.IsOlderThan(stella);
            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, isPeterOlder);
        }

        private static double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentOutOfRangeException("You must pass only numbers heigher than 0");
            }

            double semiPerimeter = (sideA + sideB + sideC) / 2;

            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));

            return area;
        }

        private static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    throw new ArgumentOutOfRangeException("Input must be between 0 and 9");
            }
        }

        private static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("You need to pass an non empty array with int");
            }

            int maxNumber = elements.Max();

            return maxNumber;
        }

        private static void PrintFormatedNumberToConsole(double number, StringFormatOtions format)
        {
            switch (format)
            {
                case StringFormatOtions.TwoDigitsAfterDecimalPoint:
                    Console.WriteLine("{0:f2}", number);
                    break;
                case StringFormatOtions.Persent:
                    Console.WriteLine("{0:p0}", number);
                    break;
                case StringFormatOtions.ShiftRight:
                    Console.WriteLine("{0,8}", number);
                    break;
                default: throw new NotImplementedException("Not supported operation");
            }
        }

        private static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        private static bool IsLineHorizontal(double y1, double y2)
        {
            bool isHorizontal = y1 == y2;
            return isHorizontal;
        }

        private static bool IsLineVertical(double x1, double x2)
        {
            bool isVertical = x1 == x2;
            return isVertical;
        }
    }
}
