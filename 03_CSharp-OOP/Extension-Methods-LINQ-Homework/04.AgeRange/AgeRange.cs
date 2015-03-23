/*
 * Problem 4. Age range
 * Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
*/
namespace _04.AgeRange
{
    using System;
    using System.Linq;
    class AgeRange
    {
        static void Main()
        {
            // creating an anonymous type to hold information about the students
            var students = new[]
            {
                new {firstName = "Alex", secondName = "Song", age = 15},
                new {firstName = "Andy", secondName = "Carrol", age = 26},
                new {firstName = "Winston", secondName = "Reid", age = 24}, 
                new {firstName = "Stewart", secondName = "Downing", age = 30},
                new {firstName = "Carlton", secondName = "Cole", age = 21},
            };

            var names = from student in students
                        where student.age >= 18 && student.age <= 24
                        select student.firstName + " " + student.secondName;

            foreach (var student in names)
            {
                Console.WriteLine(student);
            }
        }
    }
}
