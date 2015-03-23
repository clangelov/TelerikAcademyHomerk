/*
 * Problem 3. First before last
 * Write a method that from a given array of students finds all students whose first name is before its last name alphabetically.
 * Use LINQ query operators.
*/
namespace _03.FirstBeforeLast
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    class FirstBeforeLast
    {
        static void Main()
        {
            // creating an anonymous type to hold information about the students
            var students = new[]
            {
                new {firstName = "Alex", secondName = "Song"},
                new {firstName = "Andy", secondName = "Carrol"},
                new {firstName = "Winston", secondName = "Reid"}, 
                new {firstName = "Stewart", secondName = "Downing"},
                new {firstName = "Carlton", secondName = "Cole"},
            };

            FirstNameBeforeLast(students);            
        }

        // IEnumerable<dynamic> students helps to pass anonymous type as parameter
        private static void FirstNameBeforeLast(IEnumerable<dynamic> students)
        {
            var extracted = from student in students
                            where student.firstName.CompareTo(student.secondName) < 0
                            select student;

            // Option with lambda expression
            // var extracted = students.Where(x => x.firstName.CompareTo(x.secondName) < 0);

            foreach (var student in extracted)
            {
                Console.WriteLine("Student {0} {1}", student.firstName, student.secondName);
            }
        }
    }
}
