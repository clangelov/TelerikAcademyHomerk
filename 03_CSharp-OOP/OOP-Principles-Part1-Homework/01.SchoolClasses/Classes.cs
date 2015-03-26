namespace _01.SchoolClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    class Classes : BasicInfoPeopleAndObjects
    {
        private List<Student> classStudents;
        private List<Teacher> classTeachers; 
        private List<Disciplines> classDisciplines;
        private List<string> holdClassNames = new List<string>(); // Hear I will hold all classes names

        public Classes(string name)
            :base(name)
        {
            this.classStudents = new List<Student>();
            this.classTeachers = new List<Teacher>();
            this.classDisciplines = new List<Disciplines>();
            holdClassNames.Add(Name);
        }

        public override string Name 
        {
            get
            {
                return base.Name;
            }
            protected set
            {
                if (holdClassNames.Contains(value)) // Classes have unique text identifier. 
                {
                    throw new ArgumentException("This unique class name is already in use");
                }
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("You can not assign empty value");
                }
                if (value.Length < 3 || value.Length > 25)
                {
                    throw new ArgumentOutOfRangeException("Your name is too short or too long");
                }
                base.Name = value;
            }
        }
        public List<Student> ClassStudents
        {
            get
            {
                return new List<Student>(this.classStudents);
            }
        }

        public List<Teacher> ClassTeachers
        {
            get
            {
                return new List<Teacher>(this.classTeachers);
            }
        }

        public List<Disciplines> Disciplines { get; set; }

        // Add Students
        public void AddStudentToClass(Student student)
        {
            this.classStudents.Add(student);
        }

        public void AddManyStudentToClass(params Student[] student)
        {
            foreach (var item in student)
            {
                this.classStudents.Add(item);
            }
        }

        // Add Techer
        public void AddTeacherToClass(Teacher teacher)
        {
            this.classTeachers.Add(teacher);
        }

        // Add Discipline
        public void AddDisciplineToClass(Disciplines disciplines)
        {
            this.classDisciplines.Add(disciplines);
        }

        public override string ToString()
        {
            return string.Format("In Class {0}, there are {1} teachers and {2} students\n"
                , this.Name, this.classTeachers.Count, this.classStudents.Count);
        }
    }
}
