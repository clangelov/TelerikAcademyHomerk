namespace Task01.School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class School
    {
        private string name;
        private IList<Student> studentList;
        private IList<Course> courseList;

        public School(string name)
        {
            this.Name = name;
            this.studentList = new List<Student>();
            this.courseList = new List<Course>();
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

        public List<Student> StudentListInSchool
        {
            get
            {
                return new List<Student>(this.studentList);
            }
        }

        public List<Course> CourseListInSchool
        {
            get
            {
                return new List<Course>(this.courseList);
            }
        }

        public void RegisterStudent(Student studentToRegister)
        {
            if (studentToRegister == null)
            {
                throw new ArgumentNullException("You can not pass null as parameter, Student is expected");
            }

            if (this.studentList.Any(x => x.StudentNumber == studentToRegister.StudentNumber))
            {
                throw new ArgumentException("You can not add students with duplicating students numbers");
            }

            this.studentList.Add(studentToRegister);
        }

        public void AddCourse(Course courseToAdd)
        {
            if (courseToAdd == null)
            {
                throw new ArgumentNullException("You can not pass null as parameter, Course is expected");
            }

            this.courseList.Add(courseToAdd);
        }
    }
}
