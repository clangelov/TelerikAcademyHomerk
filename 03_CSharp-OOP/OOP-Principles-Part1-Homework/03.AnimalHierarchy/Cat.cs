namespace _03.AnimalHierarchy
{
    using System;
    class Cat : Animal
    {
        public Cat(string name, int age, Gender gender)
            : base(name, age, gender)
        {
        }

        // implementing the abstract method
        public override void MakeSound()
        {
            Console.WriteLine("Cat {0}: give me food, Meow", this.Name);
        }
    }
}
