namespace Task04._1.ExamPrinting
{
    using System;

    public class Printing
    {
        private const double RealmSize = 500;

        public static void Main()
        {
            double numberOfStudents = double.Parse(Console.ReadLine());

            double sheetsPerStudent = double.Parse(Console.ReadLine());

            double priceOfOneRealmPaper = double.Parse(Console.ReadLine());

            double sheetsNeeded = CalculateNeededSheets(numberOfStudents, sheetsPerStudent);

            double totalCosts = CalculateTotalCosts(sheetsNeeded, priceOfOneRealmPaper);

            Console.WriteLine("{0:F2}", totalCosts);
        }

        private static double CalculateNeededSheets(double numberOfStudents, double sheetsPerStudent)
        {
            double sheetsNeeded = (numberOfStudents * sheetsPerStudent) / RealmSize;

            return sheetsNeeded;
        }

        private static double CalculateTotalCosts(double sheetsNeeded, double priceOfOneRealmPaper)
        {
            double totalCosts = sheetsNeeded * priceOfOneRealmPaper;

            return totalCosts;
        }
    }
}
