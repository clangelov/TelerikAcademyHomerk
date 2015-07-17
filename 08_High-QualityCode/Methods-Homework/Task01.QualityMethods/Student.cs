namespace Task01.QualityMethods
{
    using System;

    internal class Student
    {
        private string firstName;
        private string lastName;
        private string otherInfo;

        public Student(string firstName, string lastName, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.OtherInfo = otherInfo;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (this.IsInputIncorrect(value))
                {
                    throw new ArgumentException("Invalid First Name");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (this.IsInputIncorrect(value))
                {
                    throw new ArgumentException("Invalid Last Name");
                }

                this.lastName = value;
            }
        }

        public string OtherInfo
        {
            get
            {
                return this.otherInfo;
            }

            set
            {
                if (this.IsInputIncorrect(value))
                {
                    throw new ArgumentException("Invalid Students Other Info");
                }

                this.otherInfo = value;
            }
        }

        public bool IsOlderThan(Student other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("You need to pass a Student object");
            }

            DateTime firstDate =
                DateTime.Parse(this.OtherInfo.Substring(this.OtherInfo.Length - 10));
            DateTime secondDate =
                DateTime.Parse(other.OtherInfo.Substring(other.OtherInfo.Length - 10));

            return firstDate < secondDate;
        }

        private bool IsInputIncorrect(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }

            return false;
        }
    }
}
