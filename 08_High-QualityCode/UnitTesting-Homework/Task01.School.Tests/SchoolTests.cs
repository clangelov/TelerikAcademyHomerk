namespace Task01.School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void TestCreatingValidSchoolNotToThrow()
        {
            var testSchool = new School("The Academy");
        }

        [TestMethod]
        public void TestCourseToHaveExpectedName()
        {
            string schoolName = "The Academy";
            var testSchool = new School(schoolName);
            Assert.AreEqual(schoolName, testSchool.Name, "Names are not equal");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestInvalidCourseNameShouldThrow()
        {
            var testSchool = new School(null);
        }

        [TestMethod]
        public void TestRegistringAValidStudentNotToThrow()
        {
            var testStudent = new Student("Andy", 10000);
            var testSchool = new School("The Academy");
            testSchool.RegisterStudent(testStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestResgistringNullToSchoolToThrow()
        {
            var testSchool = new School("The Academy");
            testSchool.RegisterStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestResgistringStudentsWithSameNumberToSchoolToThrow()
        {
            var testSchool = new School("The Academy");
            var studentOne = new Student("Andy", 10000);
            var studentTwo = new Student("Mike", 10000);
            testSchool.RegisterStudent(studentOne);
            testSchool.RegisterStudent(studentTwo);
        }

        [TestMethod]
        public void TestStudentsCountInSchoolToEqualTheRegistredNumberOfStudents()
        {
            var expectedLength = 5;
            var testSchool = new School("The Academy");
            for (int i = 0; i < expectedLength; i++)
            {
                string name = "Name #" + i.ToString();
                int number = 10000 + i;
                var testStudent = new Student(name, number);
                testSchool.RegisterStudent(testStudent);
            }

            Assert.AreEqual(expectedLength, testSchool.StudentListInSchool.Count, "The count of the students in the school is not euqal to the added number");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddingNullAsCourseToSchoolToThrow()
        {
            var testSchool = new School("The Academy");
            testSchool.AddCourse(null);
        }

        [TestMethod]
        public void TestCourseCountInSchoolToEqualTheAddedNumberOfCourses()
        {
            var expectedLength = 5;
            var testSchool = new School("The Academy");
            for (int i = 0; i < expectedLength; i++)
            {
                string name = "Course #" + i.ToString();
                var testCourse = new Course(name);
                testSchool.AddCourse(testCourse);
            }

            Assert.AreEqual(expectedLength, testSchool.CourseListInSchool.Count, "The count of the courses in the school is not euqal to the added number");
        }
    }
}
