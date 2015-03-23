namespace _09_16.Students
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    // public will help me to use Student for 18-19.GroupedByGroupNumber
    // otherwise the features will be inaccessible
    public class Student
    {
        // fields
        private string firstName;
        private string lastName;
        private int facultyNumber;
        private string telNumber;
        private string eMail;
        private List<int> marks;
        private int groupNumber;
        
        // Constructor
        public Student(string firstName, string lastName, int facultyNumber, string telNumber, string eMail, int groupNumber, params int[] marks)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FacultyNumber = facultyNumber;
            this.TelNumber = telNumber;
            this.EMail = eMail;
            this.Marks = new List<int>(marks);
            this.GroupNumber = groupNumber;
        }

        // Properties
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (CheckString(value))
                {
                    this.firstName = value;
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (CheckString(value))
                {
                    this.lastName = value;
                }
            }
        }

        public int FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }
            private set
            {
                if (CheckInt(value))
                {
                    this.facultyNumber = value;
                }
            }
        }

        public string TelNumber
        {
            get
            {
                return this.telNumber;
            }
            private set
            {
                if (CheckString(value))
                {
                    this.telNumber = value;
                }
            }
        }

        public string EMail
        {
            get
            {
                return this.eMail;
            }
            private set
            {
                if (CheckEMail(value))
                {
                    this.eMail = value;
                }
            }
        }

        public List<int> Marks
        {
            get { return this.marks; }
            set { this.marks = value; }
        }

        public int GroupNumber
        {
            get
            {
                return this.groupNumber;
            }
            private set
            {
                if (CheckInt(value))
                {
                    this.groupNumber = value;
                }
            }
        }

        // checking input data
        private bool CheckEMail(string value)
        {
            // creating a pattern how e-mails look like
            string regexCondition = @"[A-Za-z0-9_\-\+]+@[A-Za-z0-9\-]+\.([A-Za-z]{2,3})(?:\.[a-z]{2})?";

            Regex myRegex = new Regex(regexCondition);

            if (myRegex.IsMatch(value))
            {
                return true;
            }
            else
            {
                throw new ArgumentException("You have entered invalid e-mail");
            }
        }
        private bool CheckString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("You can not assign empty value");
            }
            else
            {
                return true;
            }
        }

        private bool CheckInt(int input)
        {
            if (input < 0 || input > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException("The number cant\t be less than zero and bigger than Int32 MaxValue");
            }
            else
            {
                return true;
            }
        }

        // this one I will use for problems 18 and 19
        public override string ToString()
        {
            return string.Format("Full name: {0} {1}\nFaculty number: {2}\n" +
                                 "Phone: {3}\ne-Mail: {4}\nGroup number: {5}\nMarks: {6}",
                this.firstName, this.lastName, this.facultyNumber, this.telNumber,
                this.eMail, this.groupNumber, string.Join(", ", this.marks));
        }

        //Problem 9. Student groups => eate a List<Student> with sample students.
        // It's a method which I will use and for problems 18 and 19
        public static List<Student> SampleStudents()
        {
            List<Student> sampleStudents = new List<Student>{
                new Student("Andy", "Carrol", 125406, "02 457 55 25", "andy06@mail.bg", 2, 2,5,5,3,2),
                new Student("Michael", "Dowson", 656507, "0519 5 77 65", "micky@gmail.com", 3, 6,6,6,6,6),
                new Student("Andy", "Song", 100106, "02 332 77 79", "andy_song@abv.bg", 1, 4,5,5,3,3),
                new Student("Carlton", "Cole", 777807, "032 47 46 49", "the.man@yahoo.co.uk", 2, 2,2,3,3,3),
                new Student("Ricardo", "Vaz Te", 998106, "02 865 94 24", "vazSofia@abv.bg", 2, 2,2,2,2,2),
                new Student("Alex", "Cresswell", 125405, "076 26 33 25", "alexx@abv.bg", 1, 6,5,4,3,6),
            };

            return sampleStudents;
        }
    }
}
