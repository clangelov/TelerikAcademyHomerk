namespace _09_16.Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // You can use Extention methods only in static classes 
    static class TestStudent
    {
        static void Main()
        {
            //Problem 9. Student groups
            List<Student> testStudents = Student.SampleStudents();

            // Problem 9. Student groups -> Order the students by FirstName from Group 2
            OrderByFirstName(testStudents);
            Console.WriteLine(new string('=', 50));

            // Problem 10 - Extention method -> Order the students by FirstName from Group 2
            testStudents.OrderByFirstNameLambda();
            Console.WriteLine(new string('=', 50));

            //Problem 11 -> Extract all students that have email in abv.bg
            ExtractMailLINQ(testStudents);
            Console.WriteLine(new string('=', 50));

            //Problem 12 -> Extract all students with phones in Sofia
            ExtractStudentsByPhone(testStudents);
            Console.WriteLine(new string('=', 50));

            // Problem 13 -> Select all students that have at least one mark Excellent (6)
            ExtractStudentWithExcellentMark(testStudents);
            Console.WriteLine(new string('=', 50));

            // Problem 14 - Extention method -> Extracts the students with exactly two marks "2"
            testStudents.StudentsWith2Marks2();
            Console.WriteLine(new string('=', 50));

            // Problem 15. Extract marks  of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
            ExtractStudentsMark(testStudents);
            Console.WriteLine(new string('=', 50));

            // Problem 16.* Groups
            // creating an array with Groups to be matched with the List of Students
            Groups[] arrOfGroups = new[]{            
            new Groups(1, Groups.DepartmentName.Mathematics),
            new Groups(2, Groups.DepartmentName.Philosophy),
            new Groups(3, Groups.DepartmentName.Science)
            };
            // Extract all students from "Mathematics" department.
            JoinTwoClassesAndExtract(arrOfGroups, testStudents);
            Console.WriteLine(new string('=', 50));
        }

        private static void OrderByFirstName(List<Student> testStudents)
        {
            var orderByFirstName = from student in testStudents
                                   where student.GroupNumber == 2
                                   orderby student.FirstName
                                   select student;

            foreach (var student in orderByFirstName)
            {
                Console.WriteLine("Student {0} {1} is from Group {2}"
                    , student.FirstName, student.LastName, student.GroupNumber);
            }
        }

        //Extention method
        private static void OrderByFirstNameLambda(this List<Student> testStudents)
        {
            var orderByFirstName = testStudents.Where(x => x.GroupNumber == 2).OrderBy(x => x.FirstName);

            foreach (var student in orderByFirstName)
            {
                Console.WriteLine("Student {0} {1} is from Group {2}"
                    , student.FirstName, student.LastName, student.GroupNumber);
            }
        }
        private static void ExtractMailLINQ(List<Student> testStudents)
        {
            // if the e-mail ends with abv.bg I have a match
            var extractMail = from student in testStudents
                              where student.EMail.EndsWith("abv.bg")
                              select student;

            foreach (var student in extractMail)
            {
                Console.WriteLine("{0}'s eMail is {1}"
                    , student.FirstName, student.EMail);
            }
        }
        private static void ExtractStudentsByPhone(List<Student> testStudents)
        {
            // if the phone starts with code 02 I have a match
            var phoneInSofia = from student in testStudents
                               where student.TelNumber.StartsWith("02")
                               select student;

            foreach (var student in phoneInSofia)
            {
                Console.WriteLine("{0}'s Sofia based phone is {1}"
                    , student.FirstName, student.TelNumber);
            }
        }

        private static void ExtractStudentWithExcellentMark(List<Student> testStudents)
        {
            // student.Marks.Contains(6) checks if any one of the marks equals 6 
            var excellentSocreStudents = from student in testStudents
                                         where student.Marks.Contains(6)
                                         select new // New anonymous class that has properties – FullName and Marks
                                         {
                                             studentName = string.Format("{0} {1}", student.FirstName, student.LastName),
                                             studentMarks = string.Join(", ", student.Marks)
                                         };

            foreach (var student in excellentSocreStudents)
            {
                Console.WriteLine("Student {0}, has the following marks {1}", student.studentName, student.studentMarks);
            }
        }

        // Extention method
        private static void StudentsWith2Marks2(this List<Student> testStudents)
        {
            // x.Marks.FindAll(m => m == 2) returns the number of all marks 2
            // .Count == 2 adding a second condition that the marks 2 should be only two
            var lowScoreStudents = testStudents.Where(x => x.Marks.FindAll(m => m == 2).Count == 2);

            foreach (var student in lowScoreStudents)
            {
                Console.WriteLine("Student {0} has two poor marks", student.FirstName);
            }
        }
        private static void ExtractStudentsMark(List<Student> testStudents)
        {
            // student.FacultyNumber.ToString().EndsWith("06") transfers the int to a string 
            // and checks whether it ends with 06 to meet the criteria
            var studentMarks = from student in testStudents
                               where student.FacultyNumber.ToString().EndsWith("06")
                               select student;

            foreach (var student in studentMarks)
            {
                Console.WriteLine("{0}'s marks are {1}", student.FirstName, string.Join(", ", student.Marks));
            }
        }
        private static void JoinTwoClassesAndExtract(Groups[] arrOfGroups, List<Student> testStudents)
        {
            // on groups.GroupNumber equals student.GroupNumber if this parameters equals I will be able to goin the array of Groups[] arrOfGroups with the list List<Student> testStudents
            var joinStudent = from groups in arrOfGroups
                              join student in testStudents
                              on groups.GroupNumber equals student.GroupNumber
                              select new // New anonymous class that has properties – FullName and Department
                              {
                                  name = string.Format("{0} {1}"
                                      , student.FirstName, student.LastName),
                                  department = groups.Department,
                              };

            // selecting only the Students from Mathematics department
            var extractStudent = from student in joinStudent
                                 where student.department == Groups.DepartmentName.Mathematics
                                 select student;

            foreach (var student in extractStudent)
            {
                Console.WriteLine("Student {0} is in {1} department", student.name, student.department);
            }
        }  
    }
}
