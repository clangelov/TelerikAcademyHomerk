/*
 * Problem 11. Version attribute
 * Apply the version attribute to a sample class and display its version at runtime.
*/
namespace _04.VersionAttributeProject
{
    using System;

    [Version(0, 99)]
    class TestAttribute
    {
        static void Main()
        {
            var type = typeof(TestAttribute);

            var attributes = type.GetCustomAttributes(false);

            foreach (VersionAttribute item in attributes)
            {
                Console.WriteLine("Version {0}", item.Version);
            }
        }
    }
}
