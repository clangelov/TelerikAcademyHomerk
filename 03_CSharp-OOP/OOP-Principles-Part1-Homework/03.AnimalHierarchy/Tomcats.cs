namespace _03.AnimalHierarchy
{
    using System;
    class Tomcats : Cat // Kittens and tomcats are cats. 
    {
        public Tomcats(string name, int age)
            : base(name, age, Gender.Male) // Tomcats can be only male
        {
        }

        // implementing the abstract method
        public override void MakeSound()
        {
            Console.WriteLine("Tomcat {0}: I will hunt a pigeon, Meow", this.Name);
        }
    }
}
