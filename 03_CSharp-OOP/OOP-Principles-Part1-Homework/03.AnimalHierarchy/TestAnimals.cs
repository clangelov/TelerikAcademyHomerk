/*
 * Problem 3. Animal hierarchy
 * Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods. Dogs, frogs and cats are Animals. All animals can produce sound (specified by the ISound interface). Kittens and tomcats are cats. All animals are described by age, name and sex. Kittens can be only female and tomcats can be only male. Each animal produces a specific sound.
 * Create arrays of different kinds of animals and calculate the average age of each kind of animal using a static method (you may use LINQ).
*/
namespace _03.AnimalHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class TestAnimals
    {
        static void Main()
        {
            Animal[] testAnimals = new Animal[] // Create arrays of different kinds of animals
            {
                new Dog("Rex", 3, Gender.Male),
                new Dog("Ricardo", 2, Gender.Male),
                new Dog("Patricia", 4, Gender.Female),

                new Frog("Nicolette", 2, Gender.Female),
                new Frog("Titan", 15, Gender.Male),                

                new Cat("Hell", 7, Gender.Male),
                new Cat("Kitty", 3, Gender.Female),

                new Kittens("Lolly", 1),
                new Kittens("Dolly", 6),

                new Tomcats("Pan", 1),
                new Tomcats("Zeus", 2),
                
            };

            var grouped = testAnimals.GroupBy(x => x.GetType()); // First Goup the animals based on their type

            foreach (var kind in grouped)
            {
                // than calculate the average age of each kind
                Console.WriteLine("Average {0} age is {1}", kind.Key.Name, kind.Average(x => x.Age));
            }

            Console.WriteLine(new string('=', 50));

            // Test ToString() method
            Console.WriteLine(testAnimals[0]);
            Console.WriteLine(testAnimals[3]);
            Console.WriteLine(testAnimals[8]);

            Console.WriteLine(new string('=', 50));

            //Test MakeSound method
            var groupSound = from animal in testAnimals
                             group animal by animal.GetType() // group by kind
                             into groups
                             select groups.First(); // and selecting the first element out of the group

            foreach (var animal in groupSound)
            {
                animal.MakeSound();
            }

            Console.WriteLine(new string('=', 50));
        }        
    }
}
