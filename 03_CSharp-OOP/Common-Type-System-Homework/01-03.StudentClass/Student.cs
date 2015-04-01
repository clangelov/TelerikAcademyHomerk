/*
 * Problem 1. Student class
 * Define a class Student, which contains data about a student – first, middle and last name, SSN, permanent address, mobile phone e-mail, course, specialty, university, faculty. Use an enumeration for the specialties, universities and faculties.
 * Override the standard methods, inherited by System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.
*/
namespace _01_03.StudentClass
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    public class Student : ICloneable, IComparable<Student>
    {
        private string firstName;
        private string lastName;
        private string middleName;
        private int socialSecurityNumber;
        private string adress;
        private string telNumber;
        private string eMail;
        private string course;
        private University university;
        private Faculty faculty;
        private Specialty specialty;

        public Student(string firstName, string middleName, string lastName, int socialSecurityNumber, string adress,
            string telNumber, string eMail, string course, University university, Faculty faculty, Specialty specialty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SocialSecurityNumber = socialSecurityNumber;
            this.Adress = adress;
            this.TelNumber = telNumber;
            this.EMail = eMail;
            this.Course = course;
            this.University = university;
            this.Faculty = faculty;
            this.Specialty = specialty;
        }
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (IsStringValueCorrect(value))
                {
                    this.firstName = value;
                }
            }
        }
        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            private set
            {
                if (IsStringValueCorrect(value))
                {
                    this.middleName = value;
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
                if (IsStringValueCorrect(value))
                {
                    this.lastName = value;
                }
            }
        }
        public int SocialSecurityNumber
        {
            get
            {
                return this.socialSecurityNumber;
            }
            private set
            {
                if (IsIntCorrentValue(value))
                {
                    this.socialSecurityNumber = value;
                }
            }
        }
        public string Adress
        {
            get
            {
                return this.adress;
            }
            private set
            {
                if (IsStringValueCorrect(value))
                {
                    this.adress = value;
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
                if (IsStringValueCorrect(value))
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
                if (IsEMailCorrectValue(value))
                {
                    this.eMail = value;
                }
            }
        }
        public string Course
        {
            get
            {
                return this.course;
            }
            private set
            {
                if (IsStringValueCorrect(value))
                {
                    this.course = value;
                }
            }
        }
        public University University
        {
            get
            {
                return this.university;
            }
            private set
            {
                this.university = value;
            }
        }
        public Faculty Faculty
        {
            get
            {
                return this.faculty;
            }
            private set
            {
                this.faculty = value;
            }
        }
        public Specialty Specialty
        {
            get
            {
                return this.specialty;
            }
            private set
            {
                this.specialty = value;
            }
        }

        // checking input data
        private bool IsEMailCorrectValue(string input)
        {
            // creating a pattern how e-mails look like
            string regexCondition = @"[A-Za-z0-9_\-\+]+@[A-Za-z0-9\-]+\.([A-Za-z]{2,3})(?:\.[a-z]{2})?";

            Regex myRegex = new Regex(regexCondition);

            if (myRegex.IsMatch(input))
            {
                return true;
            }
            else
            {
                throw new ArgumentException("You have entered invalid e-mail");
            }
        }
        private bool IsStringValueCorrect(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("You can not assign empty value");
            }
            if (input.Length < 3 || input.Length > 20)
            {
                throw new ArgumentOutOfRangeException("Name is either too short or too long");
            }
            else
            {
                return true;
            }
        }
        private bool IsIntCorrentValue(int input)
        {
            if (input < 100000 || input > 999999)
            {
                throw new ArgumentOutOfRangeException("Social security number must have 6 numbers");
            }
            else
            {
                return true;
            }
        }

        public override bool Equals(object equals)
        {
            var student = equals as Student;

            if (student == null)
            {
                throw new InvalidOperationException("Passed object is not a Student");
            }
            // The social security number is unique for each person
            if (this.socialSecurityNumber != student.SocialSecurityNumber)
            {
                return false;
            }

            return true;
        }

        // when Equals is overrided than it is quete easy to ovveride == & !=
        public static bool operator ==(Student first, Student second)
        {
            return object.Equals(first, second);
        }

        public static bool operator !=(Student first, Student second)
        {
            return !object.Equals(first, second);
        }
        public override string ToString()
        {
            return string.Format("I am Student {0}, and I learn at {1}", this.FirstName, this.University);
        }

        public override int GetHashCode()
        {
            return this.TelNumber.GetHashCode() ^ this.SocialSecurityNumber ^ this.EMail.GetHashCode();
        }

        // Problem 2. IClonable
        // Add implementations of the ICloneable interface. The Clone() method should 
        // deeply copy all object's fields into a new object of type Student.
        public object Clone()
        {
            Student clone = new Student(this.FirstName, this.MiddleName, this.LastName, this.SocialSecurityNumber,
                this.Adress, this.TelNumber, this.EMail, this.Course, this.University, this.Faculty, this.Specialty);

            return clone;

            // return this.MemberwiseClone(); -> you can use it if there are no parameters passed by reference          
        }

        // Problem 3. IComparable
        // Implement the IComparable<Student> interface to compare students by names and by social security number.
        public int CompareTo(Student compare)
        {
            int firstNameCompare = this.FirstName.CompareTo(compare.FirstName);
            if (firstNameCompare != 0)
            {
                return firstNameCompare;
            }
            else
            {
                if (this.SocialSecurityNumber > compare.SocialSecurityNumber)
                {
                    return 1;
                }
                else if (this.SocialSecurityNumber < compare.SocialSecurityNumber)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
