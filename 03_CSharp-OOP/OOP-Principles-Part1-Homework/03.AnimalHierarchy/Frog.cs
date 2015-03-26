namespace _03.AnimalHierarchy
{
    using System;
    class Frog : Animal
    {
        public Frog(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }

        // implementing the abstract method
        public override void MakeSound()
        {
            Console.WriteLine("Frog {0}: Kiss me!", this.Name);
        }
    }
}
