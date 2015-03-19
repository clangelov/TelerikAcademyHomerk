/*
 * Problem 11. Version attribute
*/
namespace _04.VersionAttributeProject
{
    using System;

    // Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface
        | AttributeTargets.Enum | AttributeTargets.Method)]
    class VersionAttribute : Attribute
    {
        // [Version] attribute holds a version in the format major.minor (e.g. 2.11).
        // constructor
        public VersionAttribute(int major, int minor)
        {
            this.VersionMajor = major;
            this.VersionMinor = minor;
        }

        // Properties
        public int VersionMajor { get; private set; }

        public int VersionMinor { get; private set; }

        // this will help me to display the information correctly
        public string Version
        {
            get
            {
                return string.Format("{0}.{1:00}", this.VersionMajor, this.VersionMinor);
            }
        }
    }
}
