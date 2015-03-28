namespace _01.SchoolClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    class Teacher : BasicInfoPeopleAndObjects
    {
        private List<Disciplines> discipline; // Each teacher teaches a set of disciplines
        public Teacher(string name, List<Disciplines> discipline)
            : base(name)
        {
            this.discipline = new List<Disciplines>();
            this.Disciplines = discipline;
        }
        public List<Disciplines> Disciplines
        {
            get { return new List<Disciplines>(this.discipline); }
            private set { this.discipline = value; }
        }
        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendFormat("Teacher {0} can teach you in ", this.Name);
            int count = this.Disciplines.Count;
            foreach (var item in this.Disciplines)
            {
                if (count != 1)
                {
                    result.AppendFormat("{0} and ", item.Name);
                    count--;
                }
                else
                {
                    result.AppendFormat("{0}", item.Name);
                    count--;
                }
            }
            return result.ToString();
        }
    }
}
