namespace Task01.OrderStudents
{
    using System;

    public class Student : IComparable<Student>
    {
        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompareTo(Student other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("You can not pass null as parameter");
            }

            if (this.LastName.CompareTo(other.LastName) == 0)
            {
                return this.FirstName.CompareTo(other.FirstName);
            }

            return this.LastName.CompareTo(other.LastName);
        }

        public override string ToString()
        {
            return this.LastName + " " + this.FirstName;
        }
    }
}