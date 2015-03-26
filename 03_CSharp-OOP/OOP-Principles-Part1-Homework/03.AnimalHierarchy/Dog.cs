namespace _03.AnimalHierarchy
{
    using System;
    class Dog : Animal
    {
        public Dog(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }

        // implementing the abstract method
        public override void MakeSound()
        {
            Console.WriteLine("Dog {0}: I want a cat, Bow", this.Name);
        }
    }
}
