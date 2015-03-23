/*
 * Problem 5. Order students
 * Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order.
 * Rewrite the same with LINQ.
*/
namespace _05.OrderStudents
{
    using System;
    using System.Linq;
    class OrderStudents
    {
        static void Main()
        {
            // creating an anonymous type to hold information about the students
            var students = new[]
            {
                new {firstName = "Alex", secondName = "Carrol"},
                new {firstName = "Alex", secondName = "Song"},
                new {firstName = "Carlton", secondName = "Reid"}, 
                new {firstName = "Stewart", secondName = "Downing"},
                new {firstName = "Carlton", secondName = "Cole"},
            };

            // lambda expressions
            // first name in increasing order and second name in decreasing order
            var sortedLambda = students.OrderBy(x => x.firstName)
                .ThenByDescending(x => x.secondName);

            foreach (var student in sortedLambda)
            {
                Console.WriteLine("Student: {0} {1}", student.firstName, student.secondName);
            }

            Console.WriteLine();

            // LINQ
            var sortedLINQ = from student in students
                             orderby student.firstName, student.secondName descending
                             select student;

            foreach (var student in sortedLINQ)
            {
                Console.WriteLine("Student: {0} {1}", student.firstName, student.secondName);
            }
        }
    }
}
