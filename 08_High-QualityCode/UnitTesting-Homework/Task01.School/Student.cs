namespace Task01.School
{
    using System;

    public class Student
    {
        private const int MinStudentNumber = 10000;
        private const int MaxStudentNumber = 99999;

        private string name;
        private int studentNumber;

        public Student(string name, int studentNumber)
        {
            this.Name = name;
            this.StudentNumber = studentNumber;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("You can not assign empty value");
                }

                this.name = value;
            }
        }

        public int StudentNumber
        {
            get
            {
                return this.studentNumber;
            }

            private set
            {
                if (value < MinStudentNumber || value > MaxStudentNumber)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Student numbers can be between {0} and {1}", MinStudentNumber, MaxStudentNumber));
                }

                this.studentNumber = value;
            }
        }
    }
}
