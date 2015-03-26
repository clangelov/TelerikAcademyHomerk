namespace _03.AnimalHierarchy
{    
    using System;

    // All animals are described by age, name and sex.
    abstract class Animal : ISound
    {
        private string name;
        private int age;
        private Gender gender;

        public Animal(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set // private = can't change the name later
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name can not be null or empty");
                }
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new ArgumentOutOfRangeException("Name is too short, or too long");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 1 || value > 20)
                {
                    throw new ArgumentOutOfRangeException("Age must be between 1 and 20");
                }
                this.age = value;
            }
        }

        public Gender Gender
        {
            get
            {
                return this.gender;
            }
            private set // private = can't change the Gender later
            {
                this.gender = value;
            }
        }

        // abstract method to be implemented later
        public abstract void MakeSound();
                
        public override string ToString()
        {
            // this.GetType().Name will dispaly only the name of the class
            return string.Format("{0} is a {1} years old {2}", this.Name, this.Age, this.GetType().Name);
        }
    }
}
