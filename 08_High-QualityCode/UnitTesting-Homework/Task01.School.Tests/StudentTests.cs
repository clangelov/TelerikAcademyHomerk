namespace Task01.School.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void TestCreatingValidStudentNotToThrow()
        {
            var testStudent = new Student("Andy", 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestInvalidStudentNameShouldThrow()
        {
            var testStudent = new Student(null, 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInvalidStudentMinNumberShouldThrow()
        {
            var testStudent = new Student("Andy", int.MinValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInvalidStudentMaxNumberShouldThrow()
        {
            var testStudent = new Student("Andy", int.MaxValue);
        }

        [TestMethod]
        public void TestStudentHasExpectedName()
        {
            string studentName = "Andy";
            var testStudent = new Student(studentName, 99999);
            Assert.AreEqual(studentName, testStudent.Name, "Names are not equal");
        }

        [TestMethod]
        public void TestStudentHasExpectedNumber()
        {
            int studentNumber = 99999;
            var testStudent = new Student("Andy", studentNumber);
            Assert.AreEqual(studentNumber, testStudent.StudentNumber, "Student numbers are not equal");
        }      
    }
}
