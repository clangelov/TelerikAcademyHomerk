namespace _04.PersonClass
{
    using System;
    class TestPersonClass
    {
        static void Main()
        {
            var firstPerson = new Person("Jennifer");
            var secondPerson = new Person("Anna", 21);

            Console.WriteLine(firstPerson);
            Console.WriteLine();

            Console.WriteLine(secondPerson);
            Console.WriteLine();
        }
    }
}
