/*
 * Problem 16.* Groups
 * Create a class Group with properties GroupNumber and DepartmentName.
*/
namespace _09_16.Students
{
    using System;
    class Groups
    {
        private int groupNumber;

        public Groups(int groupNumber, DepartmentName departnemnt)
        {
            this.GroupNumber = groupNumber;
            this.Department = departnemnt;
        }

        public int GroupNumber
        {
            get
            {
                return this.groupNumber;
            }
            private set
            {
                if (value < 1 || value > 9)
                {
                    throw new ArgumentOutOfRangeException("The group can be between first and ninth");
                }
                else
                {
                    this.groupNumber = value;
                }
            }
        }

        public DepartmentName Department { get; private set; }

        public enum DepartmentName
        {
            Mathematics,
            Philosophy,
            Science
        }
    }
}
