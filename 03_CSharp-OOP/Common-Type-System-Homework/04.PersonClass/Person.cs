/*
 * Problem 4. Person class
 * Create a class Person with two fields – name and age. Age can be left unspecified (may contain null value. Override ToString() to display the information of a person and if age is not specified – to say so.
*/
namespace _04.PersonClass
{
    using System;
    class Person
    {
        private string name;
        private int? age; // This allows me to set null value

        public Person(string name, int? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("You can not assign empty value");
                }
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new ArgumentOutOfRangeException("Name is either too short or too long");
                }

                this.name = value;
            }
        }

        public int? Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0 || value > 150)
                {
                    throw new ArgumentOutOfRangeException("Age must be between 0 and 150");
                }
                this.age = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}'s age is {1}", this.Name, this.Age == null ? "Unknown" : this.Age.ToString());
        }

    }
}
