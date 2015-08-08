namespace Task01.School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void TestCreatingValidCourseNotToThrow()
        {
            var testCourse = new Course("JS Applications");
        }

        [TestMethod]
        public void TestCourseToHaveExpectedName()
        {
            string courseName = "JS Applications";
            var testCourse = new Course(courseName);
            Assert.AreEqual(courseName, testCourse.Name, "Names are not equal");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestInvalidCourseNameShouldThrow()
        {
            var testCourse = new Course(null);
        }

        [TestMethod]
        public void TestAddingOneValidStudentNotToThrow()
        {
            var testStudent = new Student("Andy", 10000);
            var testCourse = new Course("JS Applications");
            testCourse.AddStudent(testStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddingNullToCourseToThrow()
        {
            var testCourse = new Course("JS Applications");
            testCourse.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAddingMoreThan30StudentsToCourseToThrow()
        {
            var testCourse = new Course("JS Applications");
            for (int i = 0; i < 31; i++)
            {
                string name = "Name #" + i.ToString();
                int number = 10000 + i;
                var testStudent = new Student(name, number);
                testCourse.AddStudent(testStudent);
            }
        }

        [TestMethod]
        public void TestCourseListToHaveSameLengthAsTheNUmberOfAddedStudents()
        {
            var expectedLength = 5;
            var testCourse = new Course("JS Applications");
            for (int i = 0; i < expectedLength; i++)
            {
                string name = "Name #" + i.ToString();
                int number = 10000 + i;
                var testStudent = new Student(name, number);
                testCourse.AddStudent(testStudent);
            }

            Assert.AreEqual(expectedLength, testCourse.StudentList.Count, "The count of the students in course are not euqal to the added number");
        }

        [TestMethod]
        public void TestCourseListToRemoveTheCorrectStudent()
        {
            int expectedStudentCount = 0;

            var testCourse = new Course("JS Applications");

            var testStudent = new Student("Andy", 10000);

            testCourse.AddStudent(testStudent);

            testCourse.RemoveStudent(testStudent);

            Assert.IsFalse(testCourse.StudentList.Contains(testStudent), "Student must heve been remeved");
            Assert.AreEqual(expectedStudentCount, testCourse.StudentList.Count, "The count of the students in course are not euqal student number");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemovingNullStudentFromCourseToThrow()
        {
            var testCourse = new Course("JS Applications");
            testCourse.RemoveStudent(null);
        }
    }
}
