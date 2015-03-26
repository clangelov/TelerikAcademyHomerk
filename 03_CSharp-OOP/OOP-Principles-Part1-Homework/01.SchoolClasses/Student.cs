namespace _01.SchoolClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Student : BasicInfoPeopleAndObjects
    {
        private int classNumber;

        private List<int> holdNumbers = new List<int>();

        public Student(string name, int classNumber)
            : base(name)
        {
            this.ClassNumber = classNumber;
            holdNumbers.Add(this.classNumber);
        }

        public int ClassNumber
        {
            get
            {
                return this.classNumber;
            }
            private set
            {
                if (value < 1 || value > 26)
                {
                    throw new ArgumentOutOfRangeException("Class numbers can be between 1 and 26");
                }
                if (holdNumbers.Contains(value))
                {
                    throw new ArgumentException("This unique class number is already in use");
                }
                this.classNumber = value;
            }
        }
        public override string ToString()
        {
 	        return string.Format("I am student {0} and my class number is {1}", this.Name, this.classNumber);
        }
    }
}
