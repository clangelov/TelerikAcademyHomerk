/*
 * Problem 2. Students and workers
 * Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method).
 * Initialize a list of 10 workers and sort them by money per hour in descending order.
 * Merge the lists and sort them by first name and last name.
*/
namespace _02.StudentsAndWorkers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class TestSortAndMerge
    {
        static void Main()
        {
            List<Student> testStudents = CreateTenStudents(); // method creating 10 Students

            List<Worker> testWorkers = CreateTenWorkers(); // method creating 10 Workers
            
            // Ordering the Students by their Grade
            var orderedStudents = testStudents.OrderBy(x => x.Grade);

            foreach (var student in orderedStudents)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine(new string('=', 50));

            // Ordering the Workers by their salary per hour
            var orderedWorkers = testWorkers.OrderByDescending(x => x.MoneyPerHour());

            foreach (var worker in orderedWorkers)
            {
                Console.WriteLine(worker);
            }

            Console.WriteLine(new string('=', 50));

            // Merge the lists and sort them by first name and last name.
            var allHumans = testStudents.Concat<Human>(testWorkers)
                .OrderBy(x => x.FirstName).ThenBy(x => x.LastName);

            foreach (var human in allHumans)
            {
                Console.WriteLine(string.Format("{0} {1}", human.FirstName, human.LastName));
            }

            Console.WriteLine(new string('=', 50));
        }

        private static List<Worker> CreateTenWorkers()
        {
            List<Worker> testWorkers = new List<Worker>
            {
                new Worker("Andy", "Cole", 30, 300),
                new Worker("Justin", "Blacke", 40, 320),
                new Worker("Niall", "Song", 25, 500),
                new Worker("Jennifer", "Styles", 35, 560),
                new Worker("Jessie", "Cole", 40, 360),
                new Worker("Harry", "Smith", 35, 437.5m),
                new Worker("Katty", "Cole", 40, 380),
                new Worker("Fred", "Perry", 40, 380),
                new Worker("Hermione", "Mayer", 30, 390),
                new Worker("Andy", "Williams", 40, 560),
            };

            return testWorkers;
        }

        private static List<Student> CreateTenStudents()
        {
            List<Student> testStudents = new List<Student>
            {
                new Student("Selena", "Gomez", 10),
                new Student("Justin", "Bieber", 8),
                new Student("Harry", "Styles", 11),
                new Student("Niall", "Horan", 11),
                new Student("Jennifer", "Gomez", 12),
                new Student("Jessie", "Styles", 11),
                new Student("Mike", "Wilson", 9),
                new Student("Harry", "Potter", 8),
                new Student("Hermione", "Granger", 10),
                new Student("Niall", "Williams", 12),
            };

            return testStudents;
        }
    }
}
