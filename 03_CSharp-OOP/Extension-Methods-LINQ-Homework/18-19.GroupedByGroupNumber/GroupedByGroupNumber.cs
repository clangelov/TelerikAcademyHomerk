/*
 * Problem 18. Grouped by GroupNumber
 * Create a program that extracts all students grouped by GroupNumber and then prints them to the console.
 * Use LINQ.
*/
namespace _18_19.GroupedByGroupNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    using _09_16.Students; //add References -> Projects -> _09_16 + (dot) Students
    static class GroupedByGroupNumber
    {
        static void Main()
        {
            // Calling the List of pre-set Students
            List<Student> testStudents = Student.SampleStudents();

            //Problem 18. Grouped by GroupNumber + LINQ
            var studentsByGroup = from student in testStudents
                                  group student by student.GroupNumber
                                    into groups
                                    select new // New anonymous class
                                    {
                                        Group = groups.Key,
                                        Students = groups.ToList()
                                    };

            studentsByGroup = studentsByGroup.OrderBy(x => x.Group);

            foreach (var groupedStudent in studentsByGroup)
            {
                Console.WriteLine("\nGroup: {0} Students:\n", groupedStudent.Group);
                Console.WriteLine("{0}", string.Join("\n\n", groupedStudent.Students));
            }

            Console.WriteLine("\nProblem 19");

            // Problem 19. Grouped by GroupName extensions
            testStudents.GroupSudentsByGroupNumber(); // calling the extention method
        }
        private static void GroupSudentsByGroupNumber(this List<Student> testStudents)
        {
            // grouped with lambda expression
            var studentsByGroup = testStudents.GroupBy(x => x.GroupNumber, (groupNumber, students) => new { Group = groupNumber, Students = students }).OrderBy(x => x.Group);

            foreach (var groupedStudent in studentsByGroup)
            {
                Console.WriteLine("\nGroup: {0} Students:\n", groupedStudent.Group);
                Console.WriteLine("{0}", string.Join("\n\n", groupedStudent.Students));
            }
        }  
    }    
}
