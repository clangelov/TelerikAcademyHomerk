namespace StudentsSystem.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Data;
    using Data.Migrations;
    using Models;

    public class Startup
    {
        private const int NumberOFStudents = 50;
        private const int NumberOFCourses = 10;
        private const int NumberOFHomeworksPerStudent = 5;

        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsDbContext, Configuration>());

            var studentsContext = new StudentsDbContext();

            CreateStudentsDb(studentsContext);

            AddSomeRandomStudents(studentsContext, NumberOFStudents);

            AddSomeRandomCourses(studentsContext, NumberOFCourses);

            AddSomeRandomHomeworks(studentsContext, NumberOFHomeworksPerStudent);
        }

        private static void AddSomeRandomHomeworks(StudentsDbContext studentsContext, int numberOFHomeworksPerStudent)
        {
            Console.WriteLine("Addding Some Homeworks...");

            var studentsDb = studentsContext.Students.ToList();

            foreach (var student in studentsDb)
            {
                for (int i = 0; i < numberOFHomeworksPerStudent; i++)
                {
                    var HomeworkToAdd = new Homework
                    {
                        HomeworkContent = RandomGenerator.GetRandomString(10, 50),
                        TimeSent = RandomGenerator.GetRandomDate(before: DateTime.Now),
                        StudentId = student.StudentId,
                        CourseId = student.Courses.FirstOrDefault().CourseId
                    };

                    studentsContext.Homeworks.Add(HomeworkToAdd);
                }
            }

            studentsContext.SaveChanges();
        }

        private static void AddSomeRandomCourses(StudentsDbContext studentsContext, int numberOFCourses)
        {
            Console.WriteLine("Addding Some Courses...");

            var studentsDb = studentsContext.Students
                .OrderBy(st => Guid.NewGuid())
                .ToList();

            var curetnStudentIndex = 0;

            for (int i = 0; i < numberOFCourses; i++)
            {
                var courseToAdd = new Course
                {
                    Name = RandomGenerator.GetRandomString(3, 20),
                    Description = RandomGenerator.GetRandomString(20, 30)
                };

                var numberOfStudentsPerCourse = 5;                

                for (int j = 0; j < numberOfStudentsPerCourse; j++)
                {
                    var currenStudentId = studentsDb[curetnStudentIndex];

                    var startDate = RandomGenerator.GetRandomDate(before: DateTime.Now.AddDays(-100));

                    courseToAdd.Students.Add(currenStudentId);

                    curetnStudentIndex++;
                }

                studentsContext.Courses.Add(courseToAdd);
            }

            studentsContext.SaveChanges();
        }

        private static void AddSomeRandomStudents(StudentsDbContext studentsContext, int numberOFStyudents)
        {

            Console.WriteLine("Adding Some Students...");

            for (int i = 0; i < numberOFStyudents; i++)
            {
                var studentToAdd = new Student
                {
                    Name = RandomGenerator.GetRandomString(0, 20),
                    Age = RandomGenerator.GetRandomNumber(20, 30),
                    StudentNumber = RandomGenerator.GetRandomNumber(1000, 10000)
                };

                studentsContext.Students.Add(studentToAdd);
            }

            studentsContext.SaveChanges();
        }

        public static void CreateStudentsDb(StudentsDbContext studentsContext)
        {
            var result = studentsContext.Database.CreateIfNotExists();

            Console.WriteLine("StudentsDb is created: {0}", result ? "YES" : "NO");
        }

    }
}
