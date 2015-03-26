namespace _02.StudentsAndWorkers
{
    using System;

    // Define new class Student which is derived from Human and has new field – grade
    class Student : Human
    {
        private int grade;

        public Student(string firstName, string secondName, int grade)
            : base(firstName, secondName) // re-using the parent constructor
        {
            this.Grade = grade;
        }
        public int Grade
        {
            get
            {
                return this.grade;
            }
            private set
            {
                if (value < 8 || value > 12)
                {
                    throw new ArgumentOutOfRangeException("Grades must be between 8 and 12");
                }
                this.grade = value;
            }
        }

        // implementing the abstract method
        protected override string DisplayInfoAboutYourself()
        {
            return string.Format("{0} is a student from {1}th Grade", this.FirstName, this.Grade);
        }
    }
}
