namespace Task01.School
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private const int MaxStudentsCount = 30;

        private string name;
        private IList<Student> studentList;

        public Course(string name)
        {
            this.Name = name;
            this.studentList = new List<Student>();
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

                this.name = value;
            }
        }

        public List<Student> StudentList
        {
            get
            {
                return new List<Student>(this.studentList);
            }
        }

        public void AddStudent(Student studentToAdd)
        {
            if (studentToAdd == null)
            {
                throw new ArgumentNullException("You can not pass null as parameter, Student is expected");
            }

            if (this.studentList.Count >= MaxStudentsCount)
            {
                throw new ArgumentOutOfRangeException("Class is full, you can not add more students");
            }

            this.studentList.Add(studentToAdd);
        }

        public void RemoveStudent(Student studentToRemove)
        {
            if (studentToRemove == null)
            {
                throw new ArgumentNullException("You can not pass null as parameter, Student is expected");
            }

            this.studentList.Remove(studentToRemove);
        }
    }
}
