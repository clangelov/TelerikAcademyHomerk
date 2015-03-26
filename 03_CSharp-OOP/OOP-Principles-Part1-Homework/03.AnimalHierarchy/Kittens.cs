namespace _03.AnimalHierarchy
{
    using System;
    class Kittens : Cat // Kittens and tomcats are cats. 
    {
        public Kittens(string name, int age)
            : base(name, age, Gender.Female) // Kittens can be only female
        {
        }

        // implementing the abstract method
        public override void MakeSound()
        {
            Console.WriteLine("Kitten {0}: I am beautiful, Meow", this.Name);
        }
    }
}
