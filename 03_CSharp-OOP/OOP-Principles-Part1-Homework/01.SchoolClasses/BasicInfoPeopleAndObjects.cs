namespace _01.SchoolClasses
{
    // Students, classes, teachers and disciplines have a name and they can make comments
    // so I created this Parent class for all of them
    using System;
    class BasicInfoPeopleAndObjects : IOptionalComment
    {
        private string name;

        protected BasicInfoPeopleAndObjects(string name)
        {
            this.Name = name;
        }

        public virtual string Name
        {
            get
            {
                return this.name;
            }
            protected set // you can set the value only when it is initialised
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("You can not assign empty value");
                }
                if (value.Length < 3 || value.Length > 25)
                {
                    throw new ArgumentOutOfRangeException("Your name is too short or too long");
                }
                this.name = value;
            }
        }

        // all the classes bellow BasicInfo will have this functionality and if they want they can override it
        public virtual string Comment { get; set; }
    }
}
