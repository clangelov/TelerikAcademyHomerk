namespace Task01.ClassChef.Vegetables
{
    using System;

    public abstract class Vegetable
    {
        public Vegetable()
        {
            this.IsRotten = false;
            this.IsPeeled = false;
            this.isCutted = false;
        }

        public bool IsRotten { get; set; }

        public bool IsPeeled { get; set; }

        public bool isCutted { get; set; }

        public static void Peel(Vegetable someVegatable)
        {
            if (someVegatable == null)
            {
                throw new ArgumentNullException("You must pass an Vegetable object");
            }

            someVegatable.IsPeeled = true;
        }
    }
}
